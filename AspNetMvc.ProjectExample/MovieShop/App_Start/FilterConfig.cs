using System.Web;
using System.Web.Mvc;

namespace MovieShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // This is the most general configuration for Authorization in the app
            filters.Add(new RequireHttpsAttribute()); // My applications' endpoints will not be longer available for HTTP
        }
    }
}
