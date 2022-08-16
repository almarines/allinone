using System.Collections.Generic;

namespace Domain.Training.Repositories {
	public interface ITrainingRepository {
		IEnumerable<Models.Training> GetAllTrainings();
	}
}
