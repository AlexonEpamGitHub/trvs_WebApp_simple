using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews(options =>
{
    // Add global filters equivalent to HandleErrorAttribute
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute());
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Import routing configuration from RouteConfig.cs
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Additional custom routes
    endpoints.MapControllerRoute(
        name: "customRoute",
        pattern: "Custom/{controller}/{action}/{id?}");

    endpoints.MapControllerRoute(
        name: "adminRoute",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
});

app.Run();