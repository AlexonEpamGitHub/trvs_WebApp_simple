using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public class HandleErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Custom error handling logic can be implemented here.
            // For demonstration purposes, this is left empty.
        }
    }

    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(IServiceCollection services)
        {
            services.AddScoped<HandleErrorFilter>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.AddService<HandleErrorFilter>();
            });
        }
    }
}