using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainings.Domain.Interfaces
{
   public interface ITrainingContext
    {
        IEnumerable<Training> GetAllTrainings();
        BsonValue InsertTraining(Training training);
    }
}
