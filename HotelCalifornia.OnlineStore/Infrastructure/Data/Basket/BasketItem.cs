using System;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Basket
{
    public class BasketItem
    {
        public BasketItem(Guid id, Guid thingyId)
        {
            this.Id = id;
            this.ThingyId = thingyId;
        }
        protected BasketItem()
        {

        }

        public Guid Id { get; private set; }
        public Guid ThingyId { get; private set; }
    }
}