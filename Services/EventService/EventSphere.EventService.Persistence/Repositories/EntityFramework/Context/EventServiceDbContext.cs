using EventSphere.EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.EventService.Persistence.Repositories.EntityFramework.Context
{
    public class EventServiceDbContext(DbContextOptions<EventServiceDbContext> opt) : DbContext(opt)
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSession> EventSessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.RecordId);
            });
            modelBuilder.Entity<EventSession>(entity =>
            {
                entity.HasKey(e => e.RecordId);
            });
            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.HasKey(e => e.RecordId);
            });
        }
    }
}
