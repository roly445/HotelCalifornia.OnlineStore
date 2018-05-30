using System;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Order
{
    public class OrderLineItem
    {
        public OrderLineItem(Guid id, Guid thingyId, decimal price)
        {
            this.Id = id;
            this.ThingyId = thingyId;
            this.Price = price;
        }
        public Guid Id { get; }
        public Guid ThingyId { get; }
        public decimal Price { get; }
    }
}