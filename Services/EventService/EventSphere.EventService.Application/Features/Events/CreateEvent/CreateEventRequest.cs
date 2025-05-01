using EventSphere.Core.Result;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.CreateEvent
{
    public class CreateEventRequest : IRequest<DataResult<CreateEventResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
