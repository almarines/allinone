using MediatR;
using Trainings.Infa.Repositories;
using Trainings.WebApi.Applications.Queries;
using Trainings.WebApi.Applications.Responses;

namespace Trainings.WebApi.Applications.QueriesHandlers;

public class GetTrainingsQueriesHandler : IRequestHandler<GetTrainingsQuery, GetTrainingsResponses>
{
    private readonly ITrainingDbContext _training;

    public GetTrainingsQueriesHandler(ITrainingDbContext training)
    {
        _training = training;        
    }

    public async Task<GetTrainingsResponses> Handle(GetTrainingsQuery request, CancellationToken cancellationToken)
    {
        var trainings = _training.GetAllTrainings();
        return await Task.FromResult(new GetTrainingsResponses() { Trainings = trainings });
    }
}
