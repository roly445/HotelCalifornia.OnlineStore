using System;
using System.Collections.Generic;

namespace HotelCalifornia.OnlineStore.Infrastructure.Data.Order
{
    public class OrderItem
    {
        public OrderItem(Guid orderItemId, DateTime whenOrdered, string paymentRef,
            IReadOnlyCollection<OrderLineItem> lineItems)
        {
            this.OrderItemId = orderItemId;
            this.WhenOrdered = whenOrdered;
            this.PaymentRef = paymentRef;
            this.LineItems = lineItems;
        }

        public Guid OrderItemId { get; }
        public DateTime WhenOrdered { get; }
        public string PaymentRef { get; }

        public IReadOnlyCollection<OrderLineItem> LineItems { get; }
    }
}