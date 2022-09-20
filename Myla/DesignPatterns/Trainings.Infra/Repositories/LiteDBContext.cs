using Trainings.Domain.Models;
using Trainings.Domain.Repositories;
using Trainings.Infra.Options;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Trainings.Infra.Repositories
{
    public class LiteDBContext : ILiteDBContext
    {
        private readonly LiteDatabase _context;
        private static ILiteCollection<Training> collection;
        
        private string nameOfCollection = "Trainings";

        public LiteDBContext(IOptions<DbConfig> configs)
        {
            try
            {
                if (_context == null)
                {
                    _context = new LiteDatabase($"Filename={configs.Value.PathToDB};Connection=Direct");
                    collection = _context.GetCollection<Training>(nameOfCollection);
                    
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public BsonValue InsertTraining(Training training)
        {
            collection = _context.GetCollection<Training>(nameOfCollection);

            var bsonValue = collection.Insert(training);

            return bsonValue;
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            var trainings = collection.FindAll();

            return trainings;
        }

        public Training GetTrainingById(int Id)
        {
            var bs = new BsonValue(Id);

            var training = collection.FindById(bs);

            return training;
        }

        public bool UpdateTraining(Training training)
        {
            var hasUpdated = collection.Update(training);

            return hasUpdated;
        }

        public bool DeleteTrainingById(int Id)
        {
            var bs = new BsonValue(Id);

            var hasDeleted = collection.Delete(bs);

            return hasDeleted;
        }


    }
}