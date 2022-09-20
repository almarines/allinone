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
    public class GetTrainingByIdQueryHandler : IRequestHandler<GetTrainingByIdQuery, GetTrainingResponse>
    {
        private readonly ITrainingRepository _trainingRepository;

        public GetTrainingByIdQueryHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<GetTrainingResponse> Handle(GetTrainingByIdQuery request, CancellationToken cancellationToken)
        {
            var training = _trainingRepository.GetTrainingById(request.Id);
            return await Task.FromResult(new GetTrainingResponse() { Training = training });
        }
    }
}
