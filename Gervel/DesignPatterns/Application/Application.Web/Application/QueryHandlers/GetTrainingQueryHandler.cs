using Application.Web.Queries;
using Application.Web.Responses;
using Domain.Training.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Web.QueryHandlers {
	public class GetTrainingQueryHandler : IRequestHandler<GetTrainingQuery, GetTrainingResponse> {
		private readonly ITrainingRepository _trainingRepository;

		public GetTrainingQueryHandler(ITrainingRepository trainingRepository) {
			_trainingRepository = trainingRepository;
		}

		public async Task<GetTrainingResponse> Handle(GetTrainingQuery request, CancellationToken cancellationToken) {
			var trainings = _trainingRepository.GetAllTrainings();
			var response = new GetTrainingResponse() { Trainings = trainings };

			return await Task.FromResult(response);
		}
	}
}
