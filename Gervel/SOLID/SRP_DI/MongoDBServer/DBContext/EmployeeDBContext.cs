using Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace DatabaseCore {
	public class EmployeeDBContext {
		private readonly IOptions<DbConfig> _dbOptions;


		public EmployeeDBContext(IOptions<DbConfig> dbOptions) {
			_dbOptions = dbOptions;

			InitializeDatabase();
		}

		public IMongoCollection<Employee> Employees { get; private set; }

		private void InitializeDatabase() {
			try {
				var mongoDBConfig = _dbOptions.Value.PathToDB;

				var databaseName = MongoUrl.Create(mongoDBConfig)?.DatabaseName;
				var dbClient = new MongoClient(mongoDBConfig);
				var db = dbClient.GetDatabase(databaseName);

				Employees = db.GetCollection<Employee>(nameof(Employee));

			} catch {
				throw new Exception("Invalid mongo configuration or Connection string");
			}
		}

	}
}
