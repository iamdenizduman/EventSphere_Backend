using EventSphere.OrderService.Application.Dtos.Events;

namespace EventSphere.OrderService.Application.Interfaces.External
{
    public interface IEventServiceClient
    {
        Task<EventPriceDto> GetEventPriceById(int eventId);
    }
}
