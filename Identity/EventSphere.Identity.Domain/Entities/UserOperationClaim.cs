using EventSphere.Core.Entity.Abstract;

namespace EventSphere.Identity.Domain.Entities
{
    public class UserOperationClaim : BaseEntity
    {
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
