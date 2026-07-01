using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkUp.Core.Application.Interfaces.Shared;
using LinkUp.Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkUp.Infrastructure.Shared;

public static class ServicesRegistration
{
    public static void AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IFileStorageService, FileStorageService>();
        services.AddTransient<IEmailService, EmailService>();
    }
}