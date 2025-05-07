using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.PaymentService.Application.Interfaces.Repositories;
using EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Context;
using EventSphere.PaymentService.Persistence.DataAccess.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.PaymentService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<PaymentServiceDbContext>(opt =>
            {
                opt.UseSqlServer("Server=.;Database=EventSphere.PaymentServiceDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            services.AddScoped<IPaymentReadRepository, EfPaymentReadRepository>();
            services.AddScoped<IPaymentWriteRepository, EfPaymentWriteRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork<PaymentServiceDbContext>>();
        }
    }
}
