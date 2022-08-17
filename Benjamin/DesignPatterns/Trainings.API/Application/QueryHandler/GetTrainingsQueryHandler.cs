using MediatR;
using Trainings.API.Application.Queries;
using Trainings.API.Application.Responses;
using Trainings.Domain.Repositories;

namespace Trainings.API.Application.QueryHandler
{
    public class GetTrainingsQueryHandler : IRequestHandler<GetAllTrainings, GetTrainingsResponse>
    {

        private readonly ITrainingRepository _trainingRepo;
        public GetTrainingsQueryHandler(ITrainingRepository trainingRepo)
        { 
            _trainingRepo = trainingRepo;

        }
        public async Task<GetTrainingsResponse> Handle(GetAllTrainings request, CancellationToken cancellationToken)
        {
            var trainings = _trainingRepo.GetAllTrainings();
            return await Task.FromResult(new GetTrainingsResponse() { Trainings = trainings });
        }
    }
}
