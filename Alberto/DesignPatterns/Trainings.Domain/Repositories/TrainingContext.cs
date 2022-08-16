using LiteDB;
using Trainings.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Trainings.Domain.Infrastructure;
using Trainings.Domain.Interfaces;

namespace Trainings.Domain.Repositories
{
    public class TrainingContext : ITrainingContext
	{
        private readonly LiteDatabase _context;
        private static ILiteCollection<Training> collection;
        private string trainingCollection = "Training";

		public TrainingContext(IOptions<TrainingDbConfig> configs)
		{
			try
			{
				if (_context == null)
				{
					_context = new LiteDatabase($"Filename={configs.Value.PathToDB};Connection=Direct");

					collection = _context.GetCollection<Training>(trainingCollection);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Can find or create LiteDb database.", ex);
			}
		}

		public IEnumerable<Training> GetAllTrainings()
		{
			return collection.FindAll(); ;
		}

		public BsonValue InsertTraining(Training training)
		{
			collection = _context.GetCollection<Training>(trainingCollection);

			var bsonValue = collection.Insert(training);

			return bsonValue;
		}

	}
}