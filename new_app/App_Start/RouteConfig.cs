using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

public static class RouteConfig
{
    public static void ConfigureRoutes(IEndpointRouteBuilder endpoints)
    {
        // Default route configuration
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}