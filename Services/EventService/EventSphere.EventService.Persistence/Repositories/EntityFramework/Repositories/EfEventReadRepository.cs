using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.DTOs.Events.Response;
using EventSphere.EventService.Domain.Entities;
using EventSphere.EventService.Persistence.Repositories.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.EventService.Persistence.Repositories.EntityFramework.Repositories
{
    public class EfEventReadRepository : EfEntityReadRepository<Event>, IEventReadRepository
    {
        private readonly EventServiceDbContext _context;
        public EfEventReadRepository(EventServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetEventDetailsAsync()
        {
            return await _context.Events.Include(e => e.EventSessions).ThenInclude(e => e.Speaker).ToListAsync();
        }
        public async Task<Event> GetEventDetailsByIdAsync(int eventId)
        {
            return await _context.Events.Include(e => e.EventSessions).ThenInclude(e => e.Speaker).SingleOrDefaultAsync(e => e.RecordId == eventId);
        }
    }
}
