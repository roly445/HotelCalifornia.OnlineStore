using System.Collections.Generic;

namespace HotelCalifornia.OnlineStore.Features.Basket
{
    public class BasketViewModel
    {
        public readonly IReadOnlyList<BasketLineItem> BasketLineItems;

        public BasketViewModel(IReadOnlyList<BasketLineItem> basketLineItems)
        {
            this.BasketLineItems = basketLineItems;
        }
    }
}