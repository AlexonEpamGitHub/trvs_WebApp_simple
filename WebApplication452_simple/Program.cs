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
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

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