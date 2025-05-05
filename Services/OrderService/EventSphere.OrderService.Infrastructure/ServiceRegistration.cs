using EventSphere.OrderService.Application.Interfaces.External;
using EventSphere.OrderService.Application.Interfaces.Messaging;
using EventSphere.OrderService.Infrastructure.External.Services;
using EventSphere.OrderService.Infrastructure.Messaging;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace EventSphere.OrderService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderPublisher, OrderPublisher>();

            services.AddHttpClient<IEventServiceClient, EventServiceClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7049");
            });

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
