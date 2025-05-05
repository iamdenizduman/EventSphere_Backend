using EventSphere.Core.Entity.Messaging.Orders;
using EventSphere.OrderService.Application.Interfaces.Messaging;
using MassTransit;

namespace EventSphere.OrderService.Infrastructure.Messaging
{
    public class OrderPublisher : IOrderPublisher
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public OrderPublisher(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task PublishOrderCreatedAsync(OrderCreatedEvent @event)
        {
            ISendEndpoint sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:order-service-created-order-queue"));

            await sendEndPoint.Send(@event);
        }
    }
}
