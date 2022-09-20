using MediatR;
using Trainings.API.Application.Responses;

namespace Trainings.API.Application.Commands
{
    public class CreateTrainingCommand : IRequest<CreateTrainingResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
