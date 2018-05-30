using System.Collections.Generic;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy;

namespace HotelCalifornia.OnlineStore.Features.Home
{
    public class HomeViewModel
    {
        public readonly IReadOnlyList<ThingyItem> Thingies;

        public HomeViewModel(IReadOnlyList<ThingyItem> thingies)
        {
            this.Thingies = thingies;
        }
    }
}