using Trainings.Domain;

namespace Trainings.API.Application.Responses
{
    public class GetTrainingsResponse
    {
        public IEnumerable<Training> Trainings { get; set; }
    }
}
