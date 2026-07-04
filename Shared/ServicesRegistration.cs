using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LinkUp.Core.Application.Interfaces.Shared;
using LinkUp.Infrastructure.Shared.Services;

namespace LinkUp.Infrastructure.Shared
{
    public static class ServicesRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<IEmailService, EmailService>();

        }
    }
}