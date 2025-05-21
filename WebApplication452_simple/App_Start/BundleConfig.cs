using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }

    public class BundleConfig
    {
        public static void ConfigureBundles(IApplicationBuilder app)
        {
            var options = new Microsoft.AspNetCore.Http.StaticFileOptions
            {
                // Serve static files with caching and modern practices.
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 604800; // 7 days
                    ctx.Context.Response.Headers["Cache-Control"] = $"public,max-age={durationInSeconds}";
                }
            };
            app.UseStaticFiles(options);
        }
    }
}