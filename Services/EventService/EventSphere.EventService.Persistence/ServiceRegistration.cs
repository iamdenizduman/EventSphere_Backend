using EventSphere.Core.Repository.Abstract.EntityFramework;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Persistence.Repositories.EntityFramework.Context;
using EventSphere.EventService.Persistence.Repositories.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.EventService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<EventServiceDbContext>(opt =>
            {
                opt.UseSqlServer("Server=.;Database=EventSphere.EventServiceDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            services.AddScoped<IEventReadRepository, EfEventReadRepository>();
            services.AddScoped<IEventWriteRepository, EfEventWriteRepository>();
            services.AddScoped<IEventSessionReadRepository, EfEventSessionReadRepository>();
            services.AddScoped<IEventSessionWriteRepository, EfEventSessionWriteRepository>();
            services.AddScoped<ISpeakerReadRepository, EfSpeakerReadRepository>();
            services.AddScoped<ISpeakerWriteRepository, EfSpeakerWriteRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork<EventServiceDbContext>>();
        }
    }
}
