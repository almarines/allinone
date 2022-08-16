using Trainings.Domain.Models;
using LiteDB;
using System.Collections.Generic;

namespace Trainings.Domain.Repositories
{
    public interface ILiteDBContext
    {
        IEnumerable<Training> GetAllTrainings();
        Training GetTrainingById(int trainingId);
        BsonValue InsertTraining(Training training);
        bool UpdateTraining(Training training);
        bool DeleteTrainingById(int trainingId);
    }
}