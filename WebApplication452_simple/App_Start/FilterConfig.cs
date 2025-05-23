using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";

                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    if (feature != null)
                    {
                        var exception = feature.Error;

                        await context.Response.WriteAsync("<html><body>");
                        await context.Response.WriteAsync("<h1>Something went wrong</h1>");
                        await context.Response.WriteAsync("<p>An unexpected error occurred. Please try again later.</p>");
                        await context.Response.WriteAsync("</body></html>");
                    }
                });
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}