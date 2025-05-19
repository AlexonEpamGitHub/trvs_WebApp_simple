using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure MVC with views
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Enable serving static files
            app.UseStaticFiles();

            // Enable routing
            app.UseRouting();

            // Configure endpoints for controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

<!-- _Layout.cshtml -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - WebApplication452_simple</title>
    <!-- Stylesheets should be directly included here -->
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <link rel="stylesheet" href="~/Content/site.css" />
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-light bg-light">
            <a class="navbar-brand" href="/">WebApplication452_simple</a>
        </nav>
    </header>
    <div class="container">
        @RenderBody()
    </div>
    <footer class="text-center">
        <p>&copy; @DateTime.Now.Year - WebApplication452_simple</p>
    </footer>
    <!-- Scripts should be directly included here -->
    <script src="~/Scripts/jquery-3.6.0.js"></script>
    <script src="~/Scripts/jquery.validate.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/modernizr.js"></script>
</body>
</html>