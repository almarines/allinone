using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.Extensions.Options;
using Core.Options;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataBaseCore.DBContext
{
    public class EmployeeDBDapperContext
    {
        private readonly string _connectionString;
        public EmployeeDBDapperContext(IOptions<DbConfig> dbOptions)
        {
            _connectionString = dbOptions.Value.PathToDB;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
