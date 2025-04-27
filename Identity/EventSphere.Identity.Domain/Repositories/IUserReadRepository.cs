using EventSphere.Core.Repository.Interfaces;
using EventSphere.Identity.Domain.Entities;

namespace EventSphere.Identity.Domain.Repositories
{
    public interface IUserReadRepository : IEntityReadRepository<User>
    {
    }
}
