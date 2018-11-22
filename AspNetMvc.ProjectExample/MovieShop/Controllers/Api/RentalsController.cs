using MovieShop.Dtos;
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

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto rentalDto)
        {
            throw new NotImplementedException();
        }
    }
}
