using Application.Web.Responses;
using Domain.Training.Models;
using MediatR;

namespace Application.Web.Commands {
	public class CreateTrainingCommand : IRequest<CreateTrainingResponse> {
		public Training Training { get; set; }
	}
}
