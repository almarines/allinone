using Domain.Training.Models;
using System.Collections.Generic;

namespace Application.Web.Responses {
	public class GetTrainingResponse {
		public IEnumerable<Training> Trainings { get; set; }
	}
}
