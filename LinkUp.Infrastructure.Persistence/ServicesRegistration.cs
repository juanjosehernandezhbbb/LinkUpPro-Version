using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LinkUp.Core.Domain.Interfaces;
using LinkUp.Infrastructure.Persistence.Context;
using LinkUp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkUp.Infrastructure.Persistence;

public static class ServicesRegistration
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LinkUpContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(LinkUpContext).Assembly.FullName)));

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}