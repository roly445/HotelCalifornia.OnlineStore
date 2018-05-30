using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Basket;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Order;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy;
using ResultMonad;

namespace HotelCalifornia.OnlineStore.Infrastructure.DataProcessors
{
    public class PspProcessor : IPspProcessor
    {
        private readonly IBasketService _basketService;
        private readonly IOrderRepository _orderRepository;
        private readonly IThingyRepository _thingyRepository;

        public PspProcessor(IBasketService basketService, IOrderRepository orderRepository, IThingyRepository thingyRepository)
        {
            this._basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            this._orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this._thingyRepository = thingyRepository ?? throw new ArgumentNullException(nameof(thingyRepository));
        }

        public Result<Guid, PspError> ProcessResponse(dynamic pspResponseData)
        {
            if (pspResponseData.IsSuccessful)
            {
                var orderLineItems = new HashSet<OrderLineItem>();
                foreach (var basketItem in this._basketService.Items)
                {
                    var thingItem = this._thingyRepository.GetOne(basketItem.ThingyId);
                    orderLineItems.Add(new OrderLineItem(basketItem.Id, basketItem.ThingyId, thingItem.Price));
                }

                var orderId = Guid.NewGuid();
                this._orderRepository.AddOrderItem(new OrderItem(orderId, DateTime.Now, pspResponseData.GatewayRef.ToString(),
                    orderLineItems.ToImmutableHashSet()));
                this._basketService.Empty();
                return Result.Ok<Guid, PspError>(orderId);
            }

            return Result.Fail<Guid, PspError>(new PspError("Payment not successful", 101));
           
        }

        public IDictionary<string, string> PrepData(string returnUrl)
        {
            var value = this._basketService.Items.Join(this._thingyRepository.GetAll(), x => x.ThingyId, y => y.Id,
                (basketItem, thingy) => new
                {
                    thingy.Price
                }).Sum(x => x.Price);
            var paymentRef = Guid.NewGuid();
            

            return new Dictionary<string, string>
            {
                {"value", value.ToString() },
                {"paymentRef", paymentRef.ToString() },
                {"returnUrl", returnUrl }
            };

        }
    }
}