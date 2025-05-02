using EventSphere.Core.Entity.Messaging.Events;

namespace EventSphere.EventService.Application.Interfaces.Messaging
{
    public interface IEventPublisher
    {
        Task PublishEventCreatedAsync(EventCreated @event);
    }
}
