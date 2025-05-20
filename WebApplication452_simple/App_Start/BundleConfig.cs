using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using WebOptimizer;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add WebOptimizer services for bundling and minification
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.AddCssBundle("/css/bundle.css", "/css/bootstrap.css", "/css/site.css");
                pipeline.AddJavaScriptBundle("/js/bundle.js", "/js/jquery-3.6.0.js", "/js/jquery.validate.js", "/js/modernizr-2.8.3.js", "/js/bootstrap.js");
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            // Enable static file serving from the wwwroot directory
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(System.AppContext.BaseDirectory, "wwwroot")),
                RequestPath = ""
            });

            // Use WebOptimizer for handling bundles
            app.UseWebOptimizer();

            // Additional middleware can be added here
        }
    }
}

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WebApplication452_simple</title>

    <!-- CSS bundle -->
    <link href="/css/bundle.css" rel="stylesheet" />

    <!-- JavaScript bundle -->
    <script src="/js/bundle.js"></script>
</head>
<body>
    <div>
        <!-- Content goes here -->
    </div>
</body>
</html>