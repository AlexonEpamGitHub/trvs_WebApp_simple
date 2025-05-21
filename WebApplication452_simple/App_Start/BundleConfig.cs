using Microsoft.Extensions.FileProviders;
using System.IO;

namespace WebApplication452_simple
{
    public class Startup
    {
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

            // Serve static files from the wwwroot folder
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "wwwroot")),
                RequestPath = ""
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
    }

    // Note to developers:
    // Legacy bundling and minification logic has been removed. 
    // Instead of relying on outdated ASP.NET Web Optimization dependencies, developers are encouraged to use modern tools
    // such as Webpack, Gulp, or similar for handling bundling and minification of assets like JavaScript and CSS.
    // These tools provide better performance, flexibility, and are more suitable for modern web development practices.
    // To set up these tools, refer to their respective documentation and integrate them into your build process.
    // Place your static files in the "wwwroot" folder, which is the default location for serving static files in .NET Core.
    // Refer to the official .NET documentation for further guidance on managing static assets effectively.
}