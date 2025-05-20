using System.Web;

namespace WebApplication452_simple
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            // Removed BundleConfig.RegisterBundles(BundleTable.Bundles)
            // Static file references will be used instead of bundling
        }
    }
}