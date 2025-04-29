using EventSphere.Identity.Application.Common.Interfaces.Authentication;
using EventSphere.Identity.Application.Common.Interfaces.Security;
using EventSphere.Identity.Infrastructure.Common.Authentication;
using EventSphere.Identity.Infrastructure.Common.Security;
using Microsoft.Extensions.DependencyInjection;

namespace EventSphere.Identity.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IHashingHelper, HashingHelper>();
        }
    }
}
