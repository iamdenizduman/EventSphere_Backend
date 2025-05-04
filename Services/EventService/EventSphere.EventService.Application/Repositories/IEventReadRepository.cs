using EventSphere.Core.Repository.Interfaces;
using EventSphere.EventService.Domain.DTOs.Events.Response;
using EventSphere.EventService.Domain.Entities;

namespace EventSphere.EventService.Application.Repositories
{
    public interface IEventReadRepository : IEntityReadRepository<Event>
    {
        Task<List<Event>> GetEventDetailsAsync();
        Task<Event> GetEventDetailsByIdAsync(int eventId);
    }
}
