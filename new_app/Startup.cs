using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace new_app
{
    public class Startup
    {
        // Method to configure services and register dependencies.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds MVC with views support.
            services.AddControllersWithViews();

            // Additional services can be registered here (e.g., database, caching, authentication).
        }

        // Method to configure the application's HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Developer-friendly error pages.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Production exception handler and HTTPS enforcement.
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Enforces HTTPS connections.
            app.UseHttpsRedirection();

            // Middleware for serving static files.
            app.UseStaticFiles();

            // Adds routing capability.
            app.UseRouting();

            // Middleware for authorization.
            app.UseAuthorization();

            // Defines endpoint routing patterns.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}