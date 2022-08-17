using MediatR;
using Trainings.WebApi.Applications.Responses;

namespace Trainings.WebApi.Applications.Command;

public class CreateTrainingCommand : IRequest<CreateTrainingResponse>
{
        public int Id { get; set; }

        public string Name { get; set; }
}
