using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Trainings.Infa.Options;
using Trainings.WebApi.Applications.Command;
using Trainings.WebApi.Applications.Queries;

using MyTraining = Trainings.Domain.Models;

namespace Trainings.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TrainingApiController : ControllerBase
{
    private readonly ILogger<TrainingApiController> _logger;
    private readonly IMediator _mediator;

    public TrainingApiController(ILogger<TrainingApiController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult GetTrainings()
    {
        _logger.LogInformation("Getting all customers...");

        var getTrainingQuery = new GetTrainingQuery();
        var training = _mediator.Send(getTrainingQuery);

        return Ok(training);
    }

    [HttpPost]
    public async Task<IActionResult> InsertTraining(MyTraining.Training training )
    {
        _logger.LogInformation("Inserting customer...");

        var createCustomerCommand = new CreateTrainingCommand() {Id = training.Id, Name = training.Name};
        var customers = await _mediator.Send(createCustomerCommand);

        return Ok(customers.Id);
    }

}
