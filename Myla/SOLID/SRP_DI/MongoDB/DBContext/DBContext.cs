using Core.Models;
using Core.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCore.DBContext
{
    public class EmployeeDBContext
    {
        private IMongoCollection<FullTimeEmployee> _fulltimeEmployeeCollection;
        private IMongoCollection<PartTimeEmployee> _parttimeEmployeeCollection;

        public EmployeeDBContext(IOptions<DbConfig> dbOptions)
        {

            var mongoConfig = dbOptions.Value.PathToDB;

            try
            {
                var databaseName = MongoUrl.Create(mongoConfig)?.DatabaseName;
                var dbClient = new MongoClient(mongoConfig);
                var db = dbClient.GetDatabase(databaseName);

                _fulltimeEmployeeCollection = db.GetCollection<FullTimeEmployee>("FullTimeEmployees");
                _parttimeEmployeeCollection = db.GetCollection<PartTimeEmployee>("PartTimeEmployees");

            }
            catch (MongoConfigurationException)
            {
                throw new Exception("Invalid Mongo configuration or ConnectionString");
            }

        }
    }
}
