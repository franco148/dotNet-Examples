using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Ramdom
        public ActionResult Ramdom()
        {
            var movie = new Movie() { Name = "Shrek!" };

            //We can send the object to be rendered.
            return View(movie);
        }
    }
}