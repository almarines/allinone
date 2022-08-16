using Trainings.Domain.Models;
using Trainings.Domain.Repositories;
using LiteDB;
using System;
using System.Collections.Generic;

namespace Trainings.Infra.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ILiteDBContext _context;

        public TrainingRepository(ILiteDBContext context)
        {
            _context = context;
        }

        public BsonValue InsertTraining(Training training)
        {
            var bsonValue = _context.InsertTraining(training);

            return bsonValue;
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            var trainings = _context.GetAllTrainings();

            return trainings;
        }

        public Training GetTrainingById(int Id)
        {
            var training = _context.GetTrainingById(Id);

            return training;
        }

        public bool UpdateTraining(Training training)
        {
            var hasUpdated = _context.UpdateTraining(training);

            return hasUpdated;
        }

        public bool DeleteTrainingById(int Id)
        {
            var hasDeleted = _context.DeleteTrainingById(Id);

            return hasDeleted;
        }
    }
}
