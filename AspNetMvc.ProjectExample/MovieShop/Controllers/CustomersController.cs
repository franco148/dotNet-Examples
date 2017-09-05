using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    public class CustomersController : Controller
    {
        #region Controller Members

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        #endregion

        #region Utilities

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "James Franco" },
                new Customer { Id = 2, Name = "Nataly Portman" }
            };
        }

        #endregion
    }
}