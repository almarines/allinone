using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainings.API.Application.Commands;
using Trainings.API.Application.Queries;
using Trainings.Domain;

namespace Trainings.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TrainingsController : Controller
    {
        private readonly ILogger<TrainingsController> _logger;
        private readonly IMediator _mediator;

        public TrainingsController(ILogger<TrainingsController> logger, IMediator mediator)
        { 
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllTrainings()
        {
            _logger.LogInformation("Getting all customers...");

            var getCustomersQuery = new GetAllTrainings();

            var customers = _mediator.Send(getCustomersQuery);
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCustomer(Training training)
        {
            _logger.LogInformation("Inserting customer...");

            var createCustomerCommand = new CreateTrainingCommand() { Id= training.Id,Name=training.Name };
            var customers = await _mediator.Send(createCustomerCommand);

            return Ok(customers.Id);
        }



    }
}
