using EventSphere.EventService.Domain.DTOs.Events.Response;

namespace EventSphere.EventService.Application.Features.Events.GetEvents
{
    public class GetEventsResponse
    {
        public List<EventDto>? EventDtos { get; set; }
    }
}
