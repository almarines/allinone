using Trainings.Api.Application.Commands;
using Trainings.Api.Application.Responses;
using Trainings.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Trainings.Api.Application.CommandHandlers
{
    public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingResponse>
    {
        private readonly ITrainingRepository _trainingRepository;

        public CreateTrainingCommandHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<CreateTrainingResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
        {
            var result = _trainingRepository.InsertTraining(new Domain.Models.Training() { Id = request.Id, Name = request.Name });
            return await Task.FromResult(new CreateTrainingResponse { Id = result.AsInt32 });
        }
    }
}
