using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private ILiteDBServices _dbServices;

        public CustomerController(ILogger<CustomerController> logger, ILiteDBServices dbservices)
        {
            _logger = logger;
            _dbServices = dbservices;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            _logger.LogInformation("Getting all customers...");

            var customers = _dbServices.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {
            _logger.LogInformation("Getting customer by id...");

            var customer = _dbServices.GetCustomerById(customerId);

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            _logger.LogInformation("Inserting customer...");

            var bsonValue = _dbServices.InsertCustomer(customer);

            return Ok(bsonValue.RawValue);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _logger.LogInformation("Updating customer...");

            var hasUpdated = _dbServices.UpdateCustomer(customer);

            return Ok();
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            _logger.LogInformation("Deleting customer by id...");

            var hasUpdated = _dbServices.DeleteCustomerById(customerId);

            return Ok();
        }
    }
}
