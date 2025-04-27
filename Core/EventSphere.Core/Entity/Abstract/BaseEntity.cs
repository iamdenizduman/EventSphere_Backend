using EventSphere.Core.Entity.Interfaces;

namespace EventSphere.Core.Entity.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public bool Deleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
