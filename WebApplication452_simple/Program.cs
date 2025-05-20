using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApplication452_simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Environment-specific configurations
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Middleware to handle CSS and JavaScript bundling
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/bundles"))
                {
                    var bundleName = context.Request.Path.Value.Substring("/bundles".Length).TrimStart('/').ToLower();

                    if (bundleName == "styles")
                    {
                        context.Response.ContentType = "text/css";
                        await context.Response.WriteAsync("/* Bundled CSS */\n");

                        var cssFiles = new[] { "wwwroot/css/site.css" };
                        foreach (var file in cssFiles)
                        {
                            if (File.Exists(file))
                            {
                                await context.Response.WriteAsync(await File.ReadAllTextAsync(file));
                            }
                        }
                        return;
                    }
                    else if (bundleName == "scripts")
                    {
                        context.Response.ContentType = "application/javascript";
                        await context.Response.WriteAsync("// Bundled JavaScript\n");

                        var jsFiles = new[] { "wwwroot/js/site.js" };
                        foreach (var file in jsFiles)
                        {
                            if (File.Exists(file))
                            {
                                await context.Response.WriteAsync(await File.ReadAllTextAsync(file));
                            }
                        }
                        return;
                    }
                }

                await next();
            });

            // Configure Middleware
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Migrate application startup logic from Global.asax.cs
            app.Use(async (context, next) =>
            {
                // Example of logic that could have been in Application_BeginRequest
                if (context.Request.Path.StartsWithSegments("/healthcheck"))
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Healthy");
                    return;
                }

                await next();
            });

            app.Use(async (context, next) =>
            {
                // Example of logic that could have been in Application_EndRequest
                context.Response.Headers.Add("X-Processed-Time", System.DateTime.UtcNow.ToString());
                await next();
            });

            // Routing logic migrated from Global.asax.cs and RouteConfig.cs
            app.UseEndpoints(endpoints =>
            {
                // Define conventional routes
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Example for custom routes
                endpoints.MapControllerRoute(
                    name: "customRoute",
                    pattern: "custom/{controller=Custom}/{action=Index}/{param?}");

                // Area routes
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}