using EventSphere.EventService.Domain.DTOs.Events.Messaging;

namespace EventSphere.EventService.Application.Interfaces.Messaging
{
    public interface IEventPublisher
    {
        Task PublishEventCreatedAsync(EventCreated @event);
    }
}
