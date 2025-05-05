using EventSphere.Core.Entity.Abstract;
using EventSphere.OrderService.Domain.Enums;

namespace EventSphere.OrderService.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}
