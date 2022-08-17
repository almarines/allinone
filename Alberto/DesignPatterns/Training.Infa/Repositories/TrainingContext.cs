using LiteDB;
using Trainings.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Trainings.Infa.Options;
using MyTraining = Trainings.Domain.Models;


namespace Trainings.Infa.Repositories
{
    public class TrainingContext : ITraining
	{
        private readonly LiteDatabase _context;
        private static ILiteCollection<MyTraining.Training> collection;		
		private string trainingCollection = "TrainingDB";

		public TrainingContext(IOptions<TrainingDbConfig> configs )
		{
			try
			{
				if (_context == null)
				{
					_context = new LiteDatabase($"Filename={configs.Value.PathToDB};Connection=Direct");

					collection = _context.GetCollection<MyTraining.Training>(trainingCollection);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Can find or create LiteDb database.", ex);
			}
		}


		public IEnumerable<MyTraining.Training> GetAllTrainings()
		{
			return collection.FindAll(); ;
		}

		public BsonValue InsertTraining(MyTraining.Training training)
		{
			collection = _context.GetCollection<MyTraining.Training>(trainingCollection);

            var bsonValue = collection.Insert(training);

			return bsonValue;
		}
	}
}