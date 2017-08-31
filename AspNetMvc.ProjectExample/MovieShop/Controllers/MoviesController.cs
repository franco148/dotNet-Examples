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

            //Another ways to return ActionResults
            //return new ViewResult(), and return type should be ViewResult this is a good practice
            //and easier way for testing.
            /**
             * Action Results are:
             * ViewResult, PartialViewResult, ContentResult, RedirectResult, RedirectToRouteResult, JsonResult
             * FileResult, HttpNotFoundResult and EmptyResult when method is void.
             * 
             * For Example:
             * return Content("Content in the  browser.");
             * return HttpNotFound();
             * return new EmptyResult();
             * return RedirectToAction("Index", "Home", new {page =1, sortBy=name});
             */
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            /**
             * We can cal request as: /movies
             * by default is going to show 1 and Name
             * 
             * So the following is also valid: /movies?pageIndex=4&sortBy=ReleaseDate
             */
            return Content(String.Format("PageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}