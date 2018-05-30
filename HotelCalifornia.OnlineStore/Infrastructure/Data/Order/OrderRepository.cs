using LiteDB;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Order
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrderItem(OrderItem orderItem)
        {
            using (var db = new LiteRepository("Orders.db"))
            {
                db.Insert(orderItem);
            }

        }
    }
}