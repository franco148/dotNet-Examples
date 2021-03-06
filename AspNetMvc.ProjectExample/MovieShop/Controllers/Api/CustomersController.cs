﻿using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using MovieShop.Dtos;

namespace MovieShop.Controllers.Api
{
    // For applying generally authorization to all operations from a controller we need to use [Authorize] attribure, unless we
    // need to apply it by method.
    // [Authorize]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        // public IEnumerable<CustomerDto> GetCustomers()
        public IHttpActionResult GetCustomers(string query = null)
        {
            // return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            var customersQuery = _context.Customers
                                       .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
                                       
            var customerDtos = customersQuery.ToList()
                                       .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET /api/customers/1
        // public CustomerDto GetCustomer(int id)
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost] // If we do not to specify HttpPost, we need to name the method as PostCustomer.
        // public CustomerDto CreateCustomer(CustomerDto customerDto)
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            // return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        // public void UpdateCustomer(int id, CustomerDto customerDto)
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.Birthdate = customerDto.Birthdate;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        // public void DeleteCustomer(int id)
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
