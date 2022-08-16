using LiteDB;
using System.Collections.Generic;

namespace Trainings.Domain.Repositories
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetAllTrainings();
        BsonValue InsertTraining(Training training);
    }
}
