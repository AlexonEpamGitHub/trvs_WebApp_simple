using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new HandleErrorAttribute());
            });
        }
    }
}