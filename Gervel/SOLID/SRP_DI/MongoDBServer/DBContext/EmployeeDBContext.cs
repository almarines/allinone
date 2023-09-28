using Core;
using Core.Models;
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

		public IMongoCollection<FullTimeEmployee> Employees { get; private set; }

		private void InitializeDatabase() {
			try {
				var mongoDBConfig = _dbOptions.Value.PathToDB;

				var databaseName = MongoUrl.Create(mongoDBConfig)?.DatabaseName;
				var dbClient = new MongoClient(mongoDBConfig);
				var db = dbClient.GetDatabase(databaseName);

				Employees = db.GetCollection<FullTimeEmployee>(nameof(Employee));

			} catch {
				throw new Exception("Invalid mongo configuration or Connection string");
			}
		}

	}
}
