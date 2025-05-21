using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace new_app.App_Start
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(FilterCollection filters)
        {
            filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        }
    }
}