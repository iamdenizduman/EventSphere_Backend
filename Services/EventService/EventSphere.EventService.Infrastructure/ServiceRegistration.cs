using EventSphere.EventService.Application.Interfaces.Messaging;
using EventSphere.EventService.Infrastructure.Messaging.RabbitMQ;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.EventService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventPublisher, EventPublisher>();

            services.AddMassTransit(confg =>
            {
                confg.UsingRabbitMq((context, _confg) =>
                {                     
                    _confg.Host(configuration["RabbitMQ"]);      
                });
            });
        }
    }
}
