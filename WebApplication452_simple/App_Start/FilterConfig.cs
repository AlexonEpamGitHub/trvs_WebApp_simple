using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new HandleErrorAttribute());
            });
        }
    }

    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Handle the exception and set the result.
            context.ExceptionHandled = true;
            context.Result = new Microsoft.AspNetCore.Mvc.ViewResult 
            { 
                ViewName = "Error"
            };
        }
    }
}