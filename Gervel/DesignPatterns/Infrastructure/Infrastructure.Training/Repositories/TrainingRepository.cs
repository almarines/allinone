using Domain.Training.Repositories;
using System.Collections.Generic;

using Models = Domain.Training.Models;

namespace Infrastructure.Training.Repositories {
	public class TrainingRepository : ITrainingRepository {
		private readonly ITrainingDBContext _context;

		public TrainingRepository(ITrainingDBContext context) {
			_context = context;
		}

		public IEnumerable<Models.Training> GetAllTrainings() {
			return _context.DB_GetAllTrainings();
		}

		public int InsertTraining(Models.Training training) {
			return _context.DB_InsertTraining(training);
		}
	}
}
