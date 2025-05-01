namespace EventSphere.EventService.Domain.DTOs.Events.Messaging
{
    public class EventCreated
    {
        public long EventId { get; set; }
        public int Capacity { get; set; }
    }
}
