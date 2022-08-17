using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTraining = Trainings.Domain.Models;


namespace Trainings.Infa.Repositories
{
    public interface ITraining
    {
        IEnumerable<MyTraining.Training> GetAllTrainings();
        BsonValue InsertTraining(MyTraining.Training training);
    }
}
