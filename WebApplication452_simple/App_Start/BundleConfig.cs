using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC or Razor Pages services as needed
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Enable serving static files from wwwroot folder
            app.UseStaticFiles();

            // Configure routing
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

// Static files are automatically served from the wwwroot folder in ASP.NET Core.
// Ensure that your JavaScript and CSS files are placed in the following paths:
//
// wwwroot/js/jquery-{version}.js
// wwwroot/js/jquery.validate.min.js
// wwwroot/js/modernizr-{version}.js
// wwwroot/js/bootstrap.js
// wwwroot/css/bootstrap.css
// wwwroot/css/site.css

// Note: No need for explicit bundling as in System.Web.Optimization. ASP.NET Core serves static files efficiently from the wwwroot folder.