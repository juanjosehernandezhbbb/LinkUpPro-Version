using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkUp.Core.Application.Mappings;
using System.Reflection;
using LinkUp.Core.Application.Interfaces.Services;
using LinkUp.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace LinkUp.Core.Application;

public static class ServicesRegistration
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<AutoMapperProfile>();
      
        });

        services.AddTransient<IPublicacionService, PublicacionService>();
        services.AddTransient<IComentarioService, ComentarioService>();
        services.AddTransient<IReaccionService, ReaccionService>();
        services.AddTransient<ISolicitudAmistadService, SolicitudAmistadService>();
        services.AddTransient<IAmistadService, AmistadService>();
        services.AddTransient<INotificacionService, NotificacionService>();
        services.AddTransient<IBattleshipService, BattleshipService>();

    }
}