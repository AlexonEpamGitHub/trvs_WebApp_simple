using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new HandleErrorAttribute());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

    // Custom HandleErrorAttribute class for .NET Core
    public class HandleErrorAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            // Handle the exception and potentially set a result or log it
            // Example: Logging the exception (implementation depends on the logging library used)
            base.OnException(context);
        }
    }
}