using EventSphere.Identity.Domain.Repositories;
using EventSphere.Identity.Persistence.Repositories.EntityFramework;
using EventSphere.Identity.Persistence.Repositories.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.Identity.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>(opt =>
            {
                opt.UseSqlServer("Server=.;Database=IdentityDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            services.AddScoped<IUserReadRepository, EfUserReadRepository>();
            services.AddScoped<IUserWriteRepository, EfUserWriteRepository>();
            services.AddScoped<IUserOperationClaimReadRepository, EfUserOperationClaimReadRepository>();
            services.AddScoped<IUserOperationClaimWriteRepository, EfUserOperationClaimWriteRepository>();
            services.AddScoped<IOperationClaimReadRepository, EfOperationClaimReadRepository>();
            services.AddScoped<IOperationClaimWriteRepository, EfOperationClaimWriteRepository>();
        }
    }
}
