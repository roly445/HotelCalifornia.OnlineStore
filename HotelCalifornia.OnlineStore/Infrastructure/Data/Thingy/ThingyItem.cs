using System;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy
{
    public class ThingyItem
    {
        public ThingyItem(Guid id, string name, string imagePath, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.ImagePath = imagePath;
            this.Price = price;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string ImagePath { get; }
        public decimal Price { get; }
    }
}
