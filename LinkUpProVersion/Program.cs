using LinkUp.Infrastructure.Persistence.Context;
using LinkUp.Infrastructure.Identity;
using LinkUp.Infrastructure.Persistence;
using LinkUp.Core.Application;
using LinkUp.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using LinkUpProVersion.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuracion de Servicios
builder.Services.AddControllersWithViews(options =>
{
    // COMENTA ESTA LINEA TEMPORALMENTE PARA VER EL ERROR REAL
    // options.Filters.Add<GlobalExceptionFilter>();
});

// Registrar capas de arquitectura
builder.Services.AddPersistenceLayerIoc(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();

// Identidad
builder.Services.AddIdentityLayerIocForWebApp(builder.Configuration);

var app = builder.Build();

// 2. Configuracion del Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // ESTO ES LO QUE TE PERMITIRA VER EL ERROR REAL
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// El orden es crucial: Autenticacion antes de Autorizacion
app.UseAuthentication();
app.UseAuthorization();

// 3. Mapeo de Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();