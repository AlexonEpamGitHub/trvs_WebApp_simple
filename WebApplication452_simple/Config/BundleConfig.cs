using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple.Config
{
    public class BundleConfig
    {
        public static void ConfigureBundles(IServiceCollection services)
        {
            // ASP.NET Core uses built-in static file serving and bundling features.
            // No explicit bundling configuration is needed here.
        }

        public static void UseBundles(IApplicationBuilder app)
        {
            // Static files are served directly from the wwwroot folder.
            // Ensure your static files like CSS and JS are placed in wwwroot/css and wwwroot/js.

            app.UseStaticFiles();
        }
    }
}