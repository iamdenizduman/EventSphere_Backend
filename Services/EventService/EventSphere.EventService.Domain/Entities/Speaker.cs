using EventSphere.Core.Entity.Abstract;

namespace EventSphere.EventService.Domain.Entities
{
    public class Speaker : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        public ICollection<EventSession> EventSessions { get; set; }
    }
}
