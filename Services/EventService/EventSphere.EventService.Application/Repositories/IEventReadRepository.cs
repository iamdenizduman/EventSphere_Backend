using EventSphere.Core.Repository.Interfaces;
using EventSphere.EventService.Domain.Entities;

namespace EventSphere.EventService.Application.Repositories
{
    public interface IEventReadRepository : IEntityReadRepository<Event>
    {
    }
}
