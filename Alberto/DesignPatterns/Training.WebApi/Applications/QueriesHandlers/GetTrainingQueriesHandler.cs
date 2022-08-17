using Trainings.Infa.Repositories;
using Trainings.WebApi.Applications.Queries;
using Trainings.WebApi.Applications.Responses;

namespace Trainings.WebApi.Applications.QueriesHandlers;

public class GetTrainingQueriesHandler
{
    private readonly ITraining _training;

    public GetTrainingQueriesHandler(ITraining training)
    {
        _training = training;        
    }

    public async Task<GetTrainingResponses> Handle(GetTrainingQuery request, CancellationToken cancellationToken)
    {
        var training = _training.GetAllTrainings();
        return await Task.FromResult(new GetTrainingResponses() { Trainings = training });
    }
}
