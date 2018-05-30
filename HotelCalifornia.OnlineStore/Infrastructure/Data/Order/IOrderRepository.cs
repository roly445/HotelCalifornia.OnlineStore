namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Order
{
    public interface IOrderRepository
    {
        void AddOrderItem(OrderItem orderItem);
    }
}