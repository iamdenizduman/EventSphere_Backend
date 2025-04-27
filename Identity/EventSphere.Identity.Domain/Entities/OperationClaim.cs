using EventSphere.Core.Entity.Abstract;

namespace EventSphere.Identity.Domain.Entities
{
    public class OperationClaim : BaseEntity
    {
        public int RecordId { get; set; }
        public string Name { get; set; } 
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
