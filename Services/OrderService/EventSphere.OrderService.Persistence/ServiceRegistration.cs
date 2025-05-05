using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.OrderService.Application.Interfaces.Repositories;
using EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Context;
using EventSphere.OrderService.Persistence.DataAccess.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.OrderService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<OrderServiceDbContext>(opt =>
            {
                opt.UseSqlServer("Server=.;Database=EventSphere.OrderServiceDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            services.AddScoped<IOrderReadRepository, EfOrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, EfOrderWriteRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork<OrderServiceDbContext>>();
        }
    }
}
