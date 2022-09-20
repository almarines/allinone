using Trainings.Domain.Models;
using LiteDB;
using System;
using System.Collections.Generic;

namespace Trainings.Domain.Repositories
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetAllTrainings();
        Training GetTrainingById(int trainingId);
        BsonValue InsertTraining(Training training);
        bool UpdateTraining(Training training);
        bool DeleteTrainingById(int trainingId);
    }

}
