namespace EventSphere.Core.Entity.Messaging.Orders
{
    public class OrderCreatedEvent
    {
        public int EventId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}
