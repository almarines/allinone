using Trainings.Domain.Models;

namespace Trainings.WebApi.Applications.Responses;

public class GetTrainingsResponses
{
    public IEnumerable<Training> Trainings { get; set; }
    
}
