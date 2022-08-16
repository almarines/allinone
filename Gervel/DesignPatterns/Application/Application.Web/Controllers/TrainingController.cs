using Application.Web.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

		// GET: api/<TrainingController>
		[HttpGet]
		public IActionResult Get() {
			_logger.LogInformation("Getting all trainings...");

			var getTrainingQuery = new GetTrainingQuery();
			var trainings = _mediator.Send(getTrainingQuery);

			return Ok(trainings);
		}
	}
}
