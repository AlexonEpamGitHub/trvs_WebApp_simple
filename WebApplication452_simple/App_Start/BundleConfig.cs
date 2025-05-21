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
    // Bundling and minification of assets like JavaScript and CSS should be handled using modern tools
    // such as Webpack, Gulp, or similar. These tools provide better performance and flexibility.
    // Place your static files in the "wwwroot" folder, which is the default location for serving static files in .NET Core.
    // Refer to the official documentation for guidance on using these tools effectively.
}