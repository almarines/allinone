using Trainings.Api.Application.Queries;
using Trainings.Api.Application.Responses;
using Trainings.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Trainings.Api.Application.QueryHandlers
{
    public class GetTrainingsQueryHandler : IRequestHandler<GetTrainingsQuery, GetTrainingsResponse>
    {
        private readonly ITrainingRepository _trainingRepository;

        public GetTrainingsQueryHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<GetTrainingsResponse> Handle(GetTrainingsQuery request, CancellationToken cancellationToken)
        {
            var trainings = _trainingRepository.GetAllTrainings();
            return await Task.FromResult(new GetTrainingsResponse() { Trainings = trainings });
        }
    }
}
