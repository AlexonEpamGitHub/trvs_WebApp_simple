using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services to the container
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Default route
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Dummy route
                endpoints.MapControllerRoute(
                    name: "Dummy",
                    pattern: "Hotels/{action}/{id?}",
                    defaults: new { controller = "Hotels", action = "Index" });
            });
        }
    }
}