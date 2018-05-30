using System;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy;

namespace HotelCalifornia.OnlineStore.Features.Basket
{
    public class BasketLineItem
    {
        public readonly Guid BasketItemId;
        public readonly ThingyItem Thingy;

        public BasketLineItem(Guid basketItemId, ThingyItem thingy)
        {
            this.BasketItemId = basketItemId;
            this.Thingy = thingy;
        }
    }
}