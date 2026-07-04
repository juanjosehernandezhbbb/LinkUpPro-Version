using LinkUp.Infrastructure.Persistence.Context;
using LinkUp.Infrastructure.Identity;
using LinkUp.Infrastructure.Persistence;
using LinkUp.Core.Application;
using Microsoft.EntityFrameworkCore;
using LinkUpProVersion.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Servicios
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

// Registrar capas de arquitectura una sola vez
builder.Services.AddPersistenceLayerIoc(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddHttpContextAccessor();

// Identidad
builder.Services.AddIdentityLayerIocForWebApp(builder.Configuration);

var app = builder.Build();

// 2. Configuración del Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Importante para cargar tus JS, CSS e imágenes
app.UseRouting();

// El orden es crucial: Autenticación antes de Autorización
app.UseAuthentication();
app.UseAuthorization();

// 3. Mapeo de Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();