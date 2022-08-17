using Trainings.Domain.Models;

namespace Trainings.WebApi.Applications.Responses;
using MyTraining = Trainings.Domain.Models;

public class GetTrainingResponses
{
    public IEnumerable<MyTraining.Training> Trainings { get; set; }
    
}
