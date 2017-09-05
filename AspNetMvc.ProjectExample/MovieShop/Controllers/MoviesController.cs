using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Models;
using MovieShop.ViewModel;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Ramdom
        public ActionResult Ramdom()
        {
            var movie = new Movie() { Name = "Shrek!" };

            /**
             * If i send the viewmodel information, it is not going to work because
             * the view does model is MOVIE and it is not RandomMovieViewModel object.
             */
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //We can send the object to be rendered.
            return View(viewModel);

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

        /**
         * This was part of the routing implementation via hardcoding routes.
         */
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        /**
         * Some constraints are:
         * min, max, minlenght, maxlenght, int, float, guid.
         */
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseMonth(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}