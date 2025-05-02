using EventSphere.Core.Entity.Messaging.Events;
using EventSphere.EventService.Application.Interfaces.Messaging;
using MassTransit;

namespace EventSphere.EventService.Infrastructure.Messaging.RabbitMQ
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public EventPublisher(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task PublishEventCreatedAsync(EventCreated @event)
        {
            ISendEndpoint sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:event-service-created-event-queue"));

            await sendEndPoint.Send(@event);
        }
    }
}
