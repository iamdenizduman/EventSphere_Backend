using EventSphere.PaymentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Context
{
    public class PaymentServiceDbContext(DbContextOptions<PaymentServiceDbContext> opt) : DbContext(opt)
    {
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(payment =>
            {
                payment.OwnsOne(p => p.Amount, amount =>
                {
                    amount.Property(a => a.Value).HasColumnName("Amount_Value");
                    amount.Property(a => a.Currency).HasColumnName("Amount_Currency");
                });
            });
        }
    }
}
