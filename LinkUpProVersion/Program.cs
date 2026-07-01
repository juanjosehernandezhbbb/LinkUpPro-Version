using LinkUp.Infrastructure.Persistence.Context;
using LinkUp.Infrastructure.Identity;
using LinkUp.Infrastructure.Persistence;
using LinkUp.Core.Application;
using Microsoft.EntityFrameworkCore;
using LinkUp.Core.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Persistence and application layers
builder.Services.AddPersistenceLayerIoc(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddHttpContextAccessor();

// Identity services (configured in LinkUp.Infrastructure.Identity)
builder.Services.AddIdentityLayerIocForWebApp(builder.Configuration);
builder.Services.AddApplicationLayer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();


app.Run();
