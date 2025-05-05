using EventSphere.EventService.Application.Features.Events.GetEventById;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.GetEventPriceById
{
    public class GetEventPriceByIdRequest : IRequest<GetEventPriceByIdResponse>
    {
        public int Id { get; set; }
    }
}
