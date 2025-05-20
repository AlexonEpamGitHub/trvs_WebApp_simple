using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

namespace WebApplication452_simple
{
    public class BundleConfig
    {
        public static void RegisterBundles()
        {
            // Registering script files from wwwroot/js
            AddScript("jquery", "/wwwroot/js/jquery-{version}.js");
            AddScript("jqueryval", "/wwwroot/js/jquery.validate.js");
            AddScript("modernizr", "/wwwroot/js/modernizr-{version}.js");

            AddSTyle("bootstrap..");
        }
    }
}