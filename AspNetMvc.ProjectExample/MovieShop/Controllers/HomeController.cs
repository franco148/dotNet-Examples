using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MovieShop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "genre")] //This can be applied to the whole controller.
        // [OutputCache(Duration = 50, VaryByParam = "*", NoStore = true)] //This is for caching HTML
        [OutputCache(Duration = 50)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}