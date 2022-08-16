using Trainings.Api.Application.Commands;
using Trainings.Api.Application.Queries;
using Trainings.Domain.Models;
using Trainings.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainings.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ILogger<TrainingController> _logger;
        private readonly IMediator _mediator;
        private ITrainingRepository _dbServices;

        public TrainingController(ILogger<TrainingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllTrainings()
        {
            _logger.LogInformation("Getting all trainings...");

            var getTrainingsQuery = new GetTrainingsQuery();
            var trainings = _mediator.Send(getTrainingsQuery);

            return Ok(trainings);
        }

        [HttpGet("{trainingId}")]
        public IActionResult GetTrainingById(int trainingId)
        {
            _logger.LogInformation("Getting training by id...");

            var getTrainingQuery = new GetTrainingByIdQuery();
            var training = _mediator.Send(getTrainingQuery);

            return Ok(training);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTraining(Training training)
        {
            _logger.LogInformation("Inserting training...");

            var createTrainingCommand = new CreateTrainingCommand() { Id = training.Id, Name = training.Name };
            var trainings = await _mediator.Send(createTrainingCommand);

            return Ok(trainings.Id);
        }

        [HttpPut]
        public IActionResult UpdateTraining(Training training)
        {
            _logger.LogInformation("Updating training...");

            var hasUpdated = _dbServices.UpdateTraining(training);

            return Ok();
        }

        [HttpDelete("{trainingId}")]
        public IActionResult DeleteTraining(int trainingId)
        {
            _logger.LogInformation("Deleting training by id...");

            var hasUpdated = _dbServices.DeleteTrainingById(trainingId);

            return Ok();
        }
    }
}
