using EventSphere.Core.Result;
using MediatR;

namespace EventSphere.EventService.Application.Features.EventSessions.CreateEventSession
{
    public class CreateEventSessionRequest : IRequest<DataResult<CreateEventSessionResponse>>
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SpeakerId { get; set; }
    }
}
