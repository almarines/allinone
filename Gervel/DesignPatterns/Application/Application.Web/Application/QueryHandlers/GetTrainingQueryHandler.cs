using Application.Web.Queries;
using Application.Web.Responses;
using Domain.Training.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Web.QueryHandlers {
	public class GetTrainingQueryHandler : IRequestHandler<GetTrainingQuery, GetTrainingResponse> {
		private readonly ITrainingRepository _trainingRepository;

		public GetTrainingQueryHandler(ITrainingRepository customerRepository) {
			_trainingRepository = customerRepository;
		}

		public async Task<GetTrainingResponse> Handle(GetTrainingQuery request, CancellationToken cancellationToken) {
			var response = new GetTrainingResponse() { Trainings = _trainingRepository.GetAllTrainings()  };

			return await Task.FromResult(response);
		}
	}
}
