using EventSphere.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.Identity.Persistence.Repositories.EntityFramework.Context
{
    public class IdentityDbContext(DbContextOptions<IdentityDbContext> opt) : DbContext(opt)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.RecordId);
            });
            modelBuilder.Entity<UserOperationClaim>(entity =>
            {
                entity.HasKey(e => e.RecordId);
            });
            modelBuilder.Entity<OperationClaim>(entity =>
            {
                entity.HasKey(e => e.RecordId);
            });
        }
    }
}
