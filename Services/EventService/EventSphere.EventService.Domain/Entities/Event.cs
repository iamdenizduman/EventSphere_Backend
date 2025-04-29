using EventSphere.Core.Entity.Abstract;

namespace EventSphere.EventService.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public bool IsStockCreated { get; set; }

        public ICollection<EventSession> EventSessions { get; set; }
    }
}
