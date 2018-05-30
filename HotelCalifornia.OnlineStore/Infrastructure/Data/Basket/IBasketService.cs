using System;
using System.Collections.Generic;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Basket
{
    public interface IBasketService
    {
        void AddItem(Guid thingId);
        void RemoveItem(Guid basketItemId);
        IReadOnlyList<BasketItem> Items { get; }
        void Empty();
    }
}