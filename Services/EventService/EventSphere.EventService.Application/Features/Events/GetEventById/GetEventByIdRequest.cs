using EventSphere.Core.Result;
using EventSphere.EventService.Application.Features.Events.GetEvents;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.GetEventById
{
    public class GetEventByIdRequest : IRequest<DataResult<GetEventByIdResponse>>
    {
        public int EventId { get; set; }
    }

}
