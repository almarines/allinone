using Application.Web.Commands;
using Application.Web.Queries;
using Domain.Customer.Models;
using Domain.Customer.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Web.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase {
		private readonly ILogger<CustomerController> _logger;
		private readonly IMediator _mediator;
		private ICustomerRepository _dbServices;

		public CustomerController(ILogger<CustomerController> logger, IMediator mediator) {
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public IActionResult GetAllCustomers() {
			_logger.LogInformation("Getting all customers...");

			var getCustomersQuery = new GetCustomersQuery();
			var customers = _mediator.Send(getCustomersQuery);

			return Ok(customers);
		}

		[HttpGet("{customerId}")]
		public IActionResult GetCustomerById(int customerId) {
			_logger.LogInformation("Getting customer by id...");

			var customer = _dbServices.GetCustomerById(customerId);

			return Ok(customer);
		}

		[HttpPost]
		public async Task<IActionResult> InsertCustomer(Customer customer) {
			_logger.LogInformation("Inserting customer...");

			var createCustomerCommand = new CreateCustomerCommand() { City = customer.City, Id = customer.Id, CompanyName = customer.CompanyName, Name = customer.Name, PhoneNumber = customer.PhoneNumber };
			var customers = await _mediator.Send(createCustomerCommand);

			return Ok(customers.Id);
		}

		[HttpPut]
		public IActionResult UpdateCustomer(Customer customer) {
			_logger.LogInformation("Updating customer...");

			var hasUpdated = _dbServices.UpdateCustomer(customer);

			return Ok();
		}

		[HttpDelete("{customerId}")]
		public IActionResult DeleteCustomer(int customerId) {
			_logger.LogInformation("Deleting customer by id...");

			var hasUpdated = _dbServices.DeleteCustomerById(customerId);

			return Ok();
		}
	}
}
