using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainings.Domain.Models;


namespace Trainings.Infa.Repositories
{
    public interface ITrainingDbContext
    {
        IEnumerable<Training> GetAllTrainings();
        BsonValue InsertTraining(Training training);
    }
}
