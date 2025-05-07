namespace EventSphere.Core.Entity.Messaging.Orders
{
    public class OrderPaymentStartedEvent
    {
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
