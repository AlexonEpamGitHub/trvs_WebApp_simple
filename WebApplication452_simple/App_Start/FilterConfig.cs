using System.Web.Mvc;

namespace WebApplication452_simple
{
    public class FilterConfig
    {
        // Removed RegisterGlobalFilters method as the global filter configuration logic is migrated to Program.cs
    }
}

// Program.cs
using System.Web.Mvc;
using System.Web;

namespace WebApplication452_simple
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Configure global filters here
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}