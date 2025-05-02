using EventSphere.Core.Result;
using EventSphere.EventService.Application.Features.Events.CreateEvent;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.GetEvents
{
    public class GetEventsRequest : IRequest<DataResult<GetEventsResponse>>
    {
    }
}
