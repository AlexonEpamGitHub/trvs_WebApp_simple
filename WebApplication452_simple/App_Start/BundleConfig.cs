using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace WebApplication452_simple
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Enable static file serving from the wwwroot directory
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(System.AppContext.BaseDirectory, "wwwroot")),
                RequestPath = ""
            });

            // Additional middleware can be added here
        }
    }
}

<!-- Example usage of TagHelpers in Razor views -->
<!-- Replace the previous bundling mechanism with direct linking to static files -->

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WebApplication452_simple</title>

    <!-- CSS files -->
    <link href="/css/bootstrap.css" rel="stylesheet" />
    <link href="/css/site.css" rel="stylesheet" />

    <!-- JavaScript files -->
    <script src="/js/jquery-3.6.0.js"></script>
    <script src="/js/jquery.validate.js"></script>
    <script src="/js/modernizr-2.8.3.js"></script>
    <script src="/js/bootstrap.js"></script>
</head>
<body>
    <div>
        <!-- Content goes here -->
    </div>
</body>
</html>