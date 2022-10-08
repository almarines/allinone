using Core.Models;
using Core.Options;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseCore.DBContext
{
    public class EmployeeDBContext
	{
        private readonly IMongoCollection<Employee> _fullemployeeCollection;
        private readonly IMongoCollection<PartTimeEmployee> _partemployeeCollection;
        public readonly IMongoCollection<Employee> Employees;

        public EmployeeDBContext(IOptions<DbConfig> dbOptions)
        {
            var mongoDbConfig = dbOptions.Value.PathToDB;
            try
            {
                var databaseName = MongoUrl.Create(mongoDbConfig)?.DatabaseName;
                var dbClient = new MongoClient(mongoDbConfig);
                var db = dbClient.GetDatabase(databaseName);

                //_fullemployeeCollection = db.GetCollection<Employee>("FullTimeEmployees");
                //_partemployeeCollection = db.GetCollection<PartTimeEmployee>("PartTimeEmployees");
                //_partemployeeCollection = db.GetCollection<PartTimeEmployee>("Employees");
                Employees = db.GetCollection<Employee>(nameof(Employee));
            }
            catch (MongoConfigurationException)
            {
                throw new Exception("invalid mongo connection");
            }
        }

        public async Task CreateAsync(Employee model)
        {
            await Employees.InsertOneAsync(model);
        }

        public Task<DeleteResult> DeleteAsync(string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);
            return Employees.DeleteOneAsync(filter);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            IAsyncCursor<Employee> results = await Employees.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);
            IAsyncCursor<Employee> results = await Employees.FindAsync(filter);
            return await results.FirstOrDefaultAsync();
        }

        public async Task<Employee> GetByFilterAsync(FilterDefinition<Employee> filter)
        {
            IAsyncCursor<Employee> results = await Employees.FindAsync(filter);
            return await results.FirstOrDefaultAsync();
        }

        public async Task<ReplaceOneResult> UpdateAsync(Employee model, string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);
            return await Employees.ReplaceOneAsync(filter, model, new ReplaceOptions { IsUpsert = true });
        }
    }
}
