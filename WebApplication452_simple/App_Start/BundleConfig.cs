using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace WebApplication452_simple
{
    public class BundleConfig
    {
        // Configure bundling and minification manually or via ASP.NET Core Bundler and Minifier
        public static void ConfigureBundles(IApplicationBuilder app)
        {
            // Serve static files from wwwroot
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = ""
            });

            // For JavaScript files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "js")),
                RequestPath = "/js"
            });

            // For CSS files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css")),
                RequestPath = "/css"
            });

            // Note: Modernizr bundling has been removed as per the user request
        }
    }
}