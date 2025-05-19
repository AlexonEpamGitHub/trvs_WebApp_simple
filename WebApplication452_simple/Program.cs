using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.Filters.Add(new HandleErrorAttribute()));

// Register global filters.
builder.Services.Configure<MvcOptions>(options =>
{
    FilterConfig.RegisterGlobalFilters(options.Filters);
});

// Register bundles (if applicable, using static files configuration or third-party bundling libraries).
BundleConfig.RegisterBundles(builder.Services);

var app = builder.Build();

// Register all areas.
AreaRegistration.RegisterAllAreas(app.Services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Register routes.
RouteConfig.RegisterRoutes(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public static class AreaRegistration
{
    public static void RegisterAllAreas(IServiceProvider services)
    {
        // Logic to register areas (typically using reflection or area-specific initialization).
        // Example:
        // var areaManager = services.GetRequiredService<IAreaManager>();
        // areaManager.RegisterAreas();
    }
}

public static class FilterConfig
{
    public static void RegisterGlobalFilters(FilterCollection filters)
    {
        // Example global filter registration.
        // filters.Add(new CustomFilterAttribute());
    }
}

public static class RouteConfig
{
    public static void RegisterRoutes(IApplicationBuilder app)
    {
        // Example route registration logic.
        var routeBuilder = new RouteBuilder(app);
        routeBuilder.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
        app.UseRouter(routeBuilder.Build());
    }
}

public static class BundleConfig
{
    public static void RegisterBundles(IServiceCollection services)
    {
        // Example bundle registration logic.
        // Use third-party bundling libraries or configure static files for optimization.
        // Example:
        // services.AddBundleConfiguration(options =>
        // {
        //     options.AddCssBundle("/bundles/css", new[] { "site.css", "bootstrap.css" });
        // });
    }
}