using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace new_app.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure static file access
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot")),
                RequestPath = "/static"
            });

            // Example: Ensure CSS and JavaScript bundles are available
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Static resources loaded successfully.");
            });
        }
    }
}