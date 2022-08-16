using Domain.Training.Repositories;
using Infrastructure.Common.Options;
using LiteDB;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System;

using Models = Domain.Training.Models;

namespace Infrastructure.Training.Repositories {

	public class TrainingDBContext : ITrainingDBContext {
		private const string TrainingCollection = "Training";

		private readonly LiteDatabase _context;
		private static ILiteCollection<Models.Training> trainingCollection;

		public TrainingDBContext(IOptions<CommonDbConfig> configs) {
			try {
				if (_context == null) {
					_context = new LiteDatabase($"Filename={configs.Value.PathToDB};Connection=Direct");
					trainingCollection = _context.GetCollection<Models.Training>(TrainingCollection);
				}
			} catch (Exception ex) {
				throw new Exception("Can find or create LiteDb database.", ex);
			}
		}

		public IEnumerable<Models.Training> DB_GetAllTrainings() {
			return trainingCollection.FindAll();;
		}
	}
}