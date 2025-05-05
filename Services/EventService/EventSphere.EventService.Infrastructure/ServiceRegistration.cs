using EventSphere.EventService.Application.Interfaces.Messaging;
using EventSphere.EventService.Infrastructure.Messaging.RabbitMQ;
using EventSphere.EventService.Infrastructure.Messaging.RabbitMQ.Consumers;
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
                confg.AddConsumer<StockCreatedEventConsumer>();
                confg.UsingRabbitMq((context, _confg) =>
                {                     
                    _confg.Host(configuration["RabbitMQ"]);
                    _confg.ReceiveEndpoint("stock-service-created-stock-queue", e =>
                    {
                        e.ConfigureConsumer<StockCreatedEventConsumer>(context);
                    });
                });
            });
        }
    }
}