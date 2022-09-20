using LiteDB;
using Microsoft.Extensions.Options;
using Trainings.Domain;
using Trainings.Domain.Repositories.Context;
using Trainings.Infra.Options;

namespace Trainings.Infra.Context
{
    public class LiteDbContext : ILiteDBContext
    {
        private readonly LiteDatabase _context;
        private static ILiteCollection<Training> collection;
        private string nameOfCollection = "Trainings";

        public LiteDbContext(IOptions<DbConfig> config)
        {
            try
            {
                if (_context == null)
                {
                    _context = new LiteDatabase($"Filename={config.Value.PathToDB};Connection=Direct");
                    collection = _context.GetCollection<Training>(nameOfCollection);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }
        public IEnumerable<Training> GetAllTrainings()
        {
            var customers = collection.FindAll();

            return customers;
        }

        public BsonValue InsertTraining(Training training)
        {
            collection = _context.GetCollection<Training>(nameOfCollection);

            var bsonValue = collection.Insert(training);

            return bsonValue;
        }
    }
}
