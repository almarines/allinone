using LiteDB;
using System.Collections.Generic;

namespace Trainings.Domain.Repositories.Context
{
    public interface ILiteDBContext
    {
        IEnumerable<Training> GetAllTrainings();
        BsonValue InsertTraining(Training training);
    }
}
