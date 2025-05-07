using EventSphere.PaymentService.Application.Interfaces.Services.Iyzico;
using EventSphere.PaymentService.Infrastructure.Configurations;
using EventSphere.PaymentService.Infrastructure.Messaging.Consumers;
using EventSphere.PaymentService.Infrastructure.Services.Iyzico;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.PaymentService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(confg =>
            {
                confg.AddConsumer<OrderPaymentStartedEventConsumer>();

                confg.UsingRabbitMq((context, _confg) =>
                {
                    _confg.Host(configuration["RabbitMQ"]);
                    
                    _confg.ReceiveEndpoint("order-service-payment-started-order-queue", e =>
                    {
                        e.ConfigureConsumer<OrderPaymentStartedEventConsumer>(context);
                    });
                });

                services.AddScoped<IIyzicoPaymentService, IyzicoPaymentService>();
            });
        }
    }
}
