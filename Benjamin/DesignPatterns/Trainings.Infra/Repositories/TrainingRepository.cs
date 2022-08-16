using LiteDB;
using Trainings.Domain;
using Trainings.Domain.Repositories;
using Trainings.Domain.Repositories.Context;

namespace Trainings.Infra.Repositories
{
    public class TrainingRepository: ITrainingRepository
    {
        private readonly ILiteDBContext _context;

        public TrainingRepository(ILiteDBContext context)
        {
            _context = context;
        }
        public BsonValue InsertTraining(Training customer)
        {
            var bsonValue = _context.InsertTraining(customer);

            return bsonValue;
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            var customers = _context.GetAllTrainings();

            return customers;
        }

    }
}
