﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventSphere.PaymentService.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
