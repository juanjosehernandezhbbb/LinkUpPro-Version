
using LinkUp.Core.Application.Interfaces;
using LinkUp.Infrastructure.Identity.Entities;
using LinkUp.Infrastructure.Identity.Services;
using LinkUp.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Security;


namespace LinkUp.Infrastructure.Identity
{
    public static class ServicesRegistration
    {
        //Extension method - Decorator pattern
        public static void AddIdentityLayerIocForWebApp(this IServiceCollection services, IConfiguration config)
        { 
        GeneralConfiguration(services, config);

            #region Identity
            services.Configure<IdentityOptions>(opt =>
            {
                // Reglas de contraseña (están correctas según el doc)
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;

                // Bloqueo temporal: 5 intentos fallidos y 15 minutos de bloqueo
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.AllowedForNewUsers = true;

                // Correo único y activación obligatoria
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
            });

            services.AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddSignInManager()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            

            // Vigencia de tokens
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            {
                // Vigencia para el token de activación (24 horas)
                opt.TokenLifespan = TimeSpan.FromHours(24);
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = IdentityConstants.ApplicationScheme;
                opt.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                opt.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            }).AddCookie(IdentityConstants.ApplicationScheme, opt =>
            {
                // Cierre automático por inactividad de 30 minutos
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                opt.SlidingExpiration = true; // Renueva la sesión si el usuario interactúa dentro de la app

                opt.LoginPath = "/Account/Login";
                opt.AccessDeniedPath = "/Account/AccessDenied";
            });
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion
        }
        #region private methods
        private static void GeneralConfiguration(IServiceCollection services, IConfiguration config)
        {
            #region contexts
            if(config.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<IdentityContext>(

                    (serviceProvider, opt) =>
                    {
                        opt.EnableSensitiveDataLogging();
                        opt.UseSqlServer(connectionString,
                        m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
                    },
                    contextLifetime: ServiceLifetime.Scoped,
                    optionsLifetime: ServiceLifetime.Scoped
                );
            }

            #endregion
        }

        #endregion

    }


}
