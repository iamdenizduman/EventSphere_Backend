using EventSphere.EventService.Domain.Entities;

namespace EventSphere.EventService.Domain.DTOs.EventSessions.Response
{
    public class EventSessionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Speaker Speaker { get; set; }
    }
}
