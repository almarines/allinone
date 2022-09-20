using MediatR;
using Trainings.API.Application.Commands;
using Trainings.API.Application.Responses;
using Trainings.Domain;
using Trainings.Domain.Repositories;

namespace Trainings.API.Application.CommandHandler
{
    public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingResponse>
    {
        private readonly ITrainingRepository _trainingRepo;

        public CreateTrainingCommandHandler(ITrainingRepository trainingRepo)
        {
            _trainingRepo = trainingRepo;
        }

        public async Task<CreateTrainingResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
        {
            var result = _trainingRepo.InsertTraining(new Training() { Id = request.Id, Name = request.Name });
            return await Task.FromResult(new CreateTrainingResponse { Id = result.AsInt32 });
        }
    }
}
