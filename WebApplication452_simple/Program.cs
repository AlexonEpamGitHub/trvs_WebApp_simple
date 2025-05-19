using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication452_simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load configuration from appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            // Configure services based on appsettings.json
            var appSettings = builder.Configuration.GetSection("AppSettings");
            
            builder.Services.Configure<AppSettings>(appSettings);
            builder.Services.AddControllersWithViews();
            builder.Services.AddRouting();
            builder.Services.AddExceptionHandler(options =>
            {
                options.ExceptionHandlingPath = appSettings["ExceptionHandlingPath"] ?? "/Home/Error";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(appSettings["ExceptionHandlingPath"] ?? "/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add exception handling middleware.
            app.UseExceptionHandler(appSettings["ExceptionHandlingPath"] ?? "/Home/Error");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: appSettings["DefaultRoutePattern"] ?? "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

    public class AppSettings
    {
        public string ExceptionHandlingPath { get; set; }
        public string DefaultRoutePattern { get; set; }
    }
}