using System.Collections.Generic;

namespace Domain.Training.Repositories {
	public interface ITrainingDBContext {
		IEnumerable<Models.Training> DB_GetAllTrainings();
	}
}
