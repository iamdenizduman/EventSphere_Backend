using EventSphere.Core.Entity.Abstract;

namespace EventSphere.EventService.Domain.Entities
{
    public class EventSession : BaseEntity
    {
        public int RecordId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
