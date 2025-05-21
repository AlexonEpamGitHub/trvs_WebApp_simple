using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new HandleErrorFilter());
            });
        }
    }

    public class HandleErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Implement custom error handling logic here
            if (context.Exception != null)
            {
                // Example: Log the error or set a custom response
                context.Result = new ObjectResult(new
                {
                    Error = true,
                    Message = "An error occurred while processing your request."
                })
                {
                    StatusCode = 500
                };

                context.ExceptionHandled = true;
            }
        }
    }
}