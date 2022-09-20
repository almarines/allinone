using Application.Web.Commands;
using Application.Web.Queries;
using Domain.Training.Models;
using Infrastructure.Customer.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Web.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class TrainingController : ControllerBase {
		private readonly ILogger<TrainingController> _logger;
		private readonly IMediator _mediator;

		public TrainingController(ILogger<TrainingController> logger, IMediator mediator) {
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet]
		public IActionResult Get() {
			// _logger.LogInformation("Getting all trainings...");
			Logger.Instance.Log("[Custom Logger] Get trainings...");

			var getTrainingQuery = new GetTrainingQuery();
			var trainings = _mediator.Send(getTrainingQuery);

			return Ok(trainings);
		}

		[HttpPost]
		public async Task<IActionResult> InsertCustomer(Training training) {
			_logger.LogInformation("Inserting training...");

			var createTrainingCommand = new CreateTrainingCommand() { Training = training };
			var insertResponse = await _mediator.Send(createTrainingCommand);

			return Ok(insertResponse.TrainingId);
		}
	}
}
