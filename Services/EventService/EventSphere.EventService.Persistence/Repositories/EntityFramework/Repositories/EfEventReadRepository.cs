using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.Entities;
using EventSphere.EventService.Persistence.Repositories.EntityFramework.Context;

namespace EventSphere.EventService.Persistence.Repositories.EntityFramework.Repositories
{
    public class EfEventReadRepository : EfEntityReadRepository<Event>, IEventReadRepository
    {
        public EfEventReadRepository(EventServiceDbContext context) : base(context)
        {
        }
    }
}
