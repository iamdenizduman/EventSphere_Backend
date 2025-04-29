using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Identity.Domain.Entities;
using EventSphere.Identity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace EventSphere.Identity.Persistence.Repositories.EntityFramework
{
    public class EfOperationClaimReadRepository(DbContext context) : EfEntityReadRepository<OperationClaim>(context), IOperationClaimReadRepository
    {
    }
}
