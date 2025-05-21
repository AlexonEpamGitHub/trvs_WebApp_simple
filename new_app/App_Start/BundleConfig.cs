using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace new_app
{
    public class BundleConfig
    {
        public static void RegisterBundles(WebApplication app)
        {
            // Add static file serving middleware
            app.UseStaticFiles();

            // Bundling and minification configuration
            app.UseBundling(bundles =>
            {
                bundles.AddCss("/css/site.css")
                       .Include("/wwwroot/css/site.css");

                bundles.AddJs("/js/site.js")
                       .Include("/wwwroot/js/site.js");
            });
        }
    }
}