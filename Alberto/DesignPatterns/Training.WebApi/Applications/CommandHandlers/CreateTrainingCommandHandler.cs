﻿using MediatR;
using Trainings.Infa.Repositories;
using Trainings.WebApi.Applications.Command;
using Trainings.WebApi.Applications.Responses;
using MyTraining = Trainings.Domain.Models;

namespace Trainings.WebApi.Applications.CommandHandlers;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingResponse>
{
    private readonly ITraining _training;

    public CreateTrainingCommandHandler(ITraining training)
    {
        _training = training;
    }

    public async Task<CreateTrainingResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
    {
        var result = _training.InsertTraining(new MyTraining.Training(){ Id = request.Id, Name = request.Name});
        return await Task.FromResult(new CreateTrainingResponse { Id = result.AsInt32 });
    }
}
