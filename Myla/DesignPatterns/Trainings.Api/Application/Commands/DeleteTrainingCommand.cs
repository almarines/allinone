using MediatR;
using Trainings.Api.Application.Responses;

namespace Trainings.Api.Application.Commands
{
    public class DeleteTrainingCommand : IRequest<DeleteTrainingResponse>
    {

        public int Id { get; set; }

    }
}
