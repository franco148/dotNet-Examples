using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Routes have to be defined from more specific to generic.
            //Then we are going to apply regex to apply a constaints
            //The following query is going to be valid: http://localhost:54662/movies/released/9991/44
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new { year = @"\d{4}", month = @"\d{2}"});

            //What happens if we want to add a constraint where it says a range between 2015|2016?
            /**
             * Some disadvantages of this approach that in the future become a mess, and because there are
             * magic strings. So if we change action name, this is not going to work anymore.
             * 
             * To solve that, we are going to use ATTRIBUTE methods. Let's comment the implementation.
             */
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new { year = @"2015|2016", month = @"\d{2}" });

            //Using Attribute Routes
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
