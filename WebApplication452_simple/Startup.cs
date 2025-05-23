using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add controller services with views
        services.AddControllersWithViews();

        // Add database context dependency in EF Core
        // Example: services.AddDbContext<ApplicationDbContext>(options =>
        //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add session support
        services.AddSession();

        // Add caching services
        services.AddMemoryCache();

        // Add logging services
        services.AddLogging();
    }

    public void Configure(IApplicationBuilder app)
    {
        // Use exception handling middleware
        app.UseExceptionHandler("/Home/Error");

        // Ensure HTTPS redirection
        app.UseHttpsRedirection();

        // Use static files
        app.UseStaticFiles();

        // Configure routing middleware
        app.UseRouting();

        // Add session support
        app.UseSession();

        // Configure endpoint routes for controllers
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}