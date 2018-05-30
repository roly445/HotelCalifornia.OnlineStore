using System;
using System.Collections.Generic;
using System.Linq;
using HotelCalifornia.OnlineStore.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Basket
{
    public class BasketService : IBasketService
    {
        private readonly List<BasketItem> _basketItems;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;

            var basketItemsFromSession = this.Session.GetObjectFromJson<List<BasketItem>>("basket");
            this._basketItems = basketItemsFromSession ?? new List<BasketItem>();
        }

        private ISession Session => this._httpContextAccessor.HttpContext.Session;

        public void AddItem(Guid thingId)
        {
            this._basketItems.Add(new BasketItem(Guid.NewGuid(), thingId));
                        this.Save();
        }

        public void RemoveItem(Guid basketItemId)
        {
            var item = this._basketItems.FirstOrDefault(x => x.Id == basketItemId);
            if (item == null)
            {
                return;
            }

            this._basketItems.Remove(item);
            

            this.Save();
        }

        public IReadOnlyList<BasketItem> Items => this._basketItems.AsReadOnly();
        public void Empty()
        {
            this._basketItems.Clear();
            this.Save();
        }

        private void Save()
        {
            this.Session.SetObjectAsJson("basket", this._basketItems);
        }
    }
}
