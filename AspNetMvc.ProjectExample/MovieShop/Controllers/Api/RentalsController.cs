using MovieShop.Dtos;
using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieShop.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;


        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto rentalDto)
        {

            // We can analyze some scenarios, and based on that we are going to identify some
            // edge cases. - Optimiztic approach vs Defensive Approach
            // No Movies Id, Invalid Customer Id, and some invalid movie' Id.

            // Since our project is not a publid API, the following validations may not be necessary since it polutes our code.
            //if (rentalDto.MovieIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            //var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            //if (customer == null)
            //    return BadRequest("CustomerId is not valid.");

            //var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            //if (movies.Count != rentalDto.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
