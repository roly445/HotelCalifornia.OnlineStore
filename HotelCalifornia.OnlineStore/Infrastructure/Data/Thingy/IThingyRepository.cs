using System;
using System.Collections.Generic;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy
{
    public interface IThingyRepository
    {
        IReadOnlyList<ThingyItem> GetAll();
        ThingyItem GetOne(Guid id);
    }
}
