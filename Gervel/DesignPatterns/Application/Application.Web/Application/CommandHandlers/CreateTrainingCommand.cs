using Application.Web.Commands;
using Application.Web.Responses;
using Domain.Training.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Web.Application.CommandHandlers {
	public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreateTrainingResponse> {
		private readonly ITrainingRepository _trainingRepository;

		public CreateTrainingCommandHandler(ITrainingRepository trainingRepository) {
			_trainingRepository = trainingRepository;
		}

		public async Task<CreateTrainingResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken) {
			var trainingId = _trainingRepository.InsertTraining(request.Training);
			var response = new CreateTrainingResponse() { TrainingId = trainingId };

			return await Task.FromResult(response);
		}

	}
}
