using LiteDB;
using Trainings.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Trainings.Infa.Options;
using Trainings.Domain.Models;


namespace Trainings.Infa.Repositories;

public class TrainingDbContext : ITrainingDbContext
{
	private readonly LiteDatabase _context;
    private static ILiteCollection<Training> collection;		
	private string trainingCollection = "TrainingDB";

	public TrainingDbContext(IOptions<TrainingDbConfig> configs )
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
		var trainings = collection.FindAll();
		return trainings;
	}

	public BsonValue InsertTraining(Training training)
	{
		collection = _context.GetCollection<Training>(trainingCollection);

		var bsonValue = collection.Insert(training);

		return bsonValue;
	}
}