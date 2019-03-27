using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProCampHome.Models;
using ProCampHome.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCampHome.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Age = 26,
                CreatedDate = new DateTime(2019, 3, 1, 12, 0, 0),
                FirstName = "Anatolii",
                LastName = "Makarov"
            },
            new Customer
            {
                Id = 2,
                Age = 20,
                CreatedDate = new DateTime(2019, 3, 1, 12, 0, 0),
                FirstName = "Ivan",
                LastName = "Ivanov"
            },
            new Customer
            {
                Id = 3,
                Age = 20,
                CreatedDate = new DateTime(2019, 3, 1, 12, 0, 0),
                FirstName = "Petr",
                LastName = "Petrov"
            },
            new Customer
            {
                Id = 4,
                Age = 20,
                CreatedDate = new DateTime(2019, 3, 1, 12, 0, 0),
                FirstName = "Semen",
                LastName = "Semenov"
            },
            new Customer
            {
                Id = 5,
                Age = 20,
                CreatedDate = new DateTime(2019, 3, 1, 12, 0, 0),
                FirstName = "Test",
                LastName = "Testov"
            }
        };

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>The list of customers.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CustomersResponse>), 200)]
        public IActionResult GetAllCustomers()
        {
            return Ok(customers?.Select(Mapper.Map<CustomersResponse>).ToList());
        }
    }
}
