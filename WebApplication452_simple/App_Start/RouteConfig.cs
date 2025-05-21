using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace WebApplication452_simple
{
    public class RouteConfig
    {
        public static void ConfigureRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}