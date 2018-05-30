using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy
{
    public class ThingyRepository : IThingyRepository
    {
        private static List<ThingyItem> _thingies;

        public ThingyRepository()
        {
            if (_thingies == null)
            {
                _thingies = new List<ThingyItem>
                {
                    new ThingyItem(
                        Guid.Parse("fbe8bb7f-5afa-4a0c-86aa-762c6b0899f1"),
                        "Yakizu",
                        "abstract-q-c-1280-960-1.jpg",
                        11.12m
                    ),
                    new ThingyItem(
                        Guid.Parse("a5a6b5e4-cb55-47a2-8a17-548ddc35b845"),
                        "Skadel",
                        "abstract-q-c-1280-960-10.jpg",
                        39.22m
                    ),
                    new ThingyItem(
                        Guid.Parse("5ec32e89-0d1c-4c97-84a2-5e7d626d7dae"),
                        "Coinzone",
                        "abstract-q-c-1280-960-4.jpg",
                        46.36m
                    ),
                    new ThingyItem(
                        Guid.Parse("0c3052da-bccb-41ef-800e-291098c3694d"),
                        "Eabox",
                        "abstract-q-c-1280-960-5.jpg",
                        52.37m
                    ),
                    new ThingyItem(
                        Guid.Parse("548071a0-d451-4b0b-a9f9-51d962d37a99"),
                        "Plambu",
                        "abstract-q-c-1280-960-8.jpg",
                        55.68m
                    ),
                    new ThingyItem(
                        Guid.Parse("7e2f5ab2-428f-4ccc-a4f4-5dc64dc7ed03"),
                        "Rifffox",
                        "abstract-q-c-1280-960-9.jpg",
                        17.06m
                    )
                };
            }
        }

        public IReadOnlyList<ThingyItem> GetAll()
        {
            return _thingies.AsReadOnly();
        }

        public ThingyItem GetOne(Guid id)
        {
            return _thingies.SingleOrDefault(thingy => thingy.Id == id);
        }
    }
}