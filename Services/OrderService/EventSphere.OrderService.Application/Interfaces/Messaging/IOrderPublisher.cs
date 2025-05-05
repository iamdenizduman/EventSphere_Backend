using EventSphere.Core.Entity.Messaging.Orders;

namespace EventSphere.OrderService.Application.Interfaces.Messaging
{
    public interface IOrderPublisher
    {
        Task PublishOrderCreatedAsync(OrderCreatedEvent @event);
    }
}
