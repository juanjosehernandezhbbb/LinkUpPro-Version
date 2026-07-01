using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Interfaces;
using LinkUp.Infrastructure.Persistence.Context;
using LinkUp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkUp.Infrastructure.Persistence;

public static class ServicesRegistration
{
    //Extension method - Decorator pattern
    public static void AddPersistenceLayerIoc(this IServiceCollection services, IConfiguration config)
    {
        #region Contexts
        if (config.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<LinkUpContext>(opt =>
                                          opt.UseInMemoryDatabase("AppDb"));
        }
        else
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<LinkUpContext>(
              (serviceProvider, opt) =>
              {
                  opt.EnableSensitiveDataLogging();
                  opt.UseSqlServer(connectionString,
                      m => m.MigrationsAssembly(typeof(LinkUpContext).Assembly.FullName));
              },
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Scoped
             );

        #endregion

            #region Repositories & Unit of Work
            // Generic repository for entities
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Unit of Work to commit changes
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}