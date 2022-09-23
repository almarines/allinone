using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseCore.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace DataBaseCore
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBDapperContext _employeeDBContext;

        public EmployeeRepository(EmployeeDBDapperContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        public async Task<Employee> Get(int id)
        {
            var query = $"SELECT * FROM Employees WHERE Id = {id}";

            using var connection = _employeeDBContext.CreateConnection();
            var emps = await connection.QueryFirstAsync<Employee>(query);

            var payments = await connection.QueryFirstAsync<Payment>("select * from Payment where Id =@id", new { id });
            emps.Salary = payments;

            return emps;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var query = "SELECT * FROM Employees";

            using var connection = _employeeDBContext.CreateConnection();
            var emps = await connection.QueryAsync<Employee>(query);

            var payments = await connection.QueryAsync<Payment>("select * from Payment");
            emps.ToList().ForEach(s => s.Salary = payments.FirstOrDefault(x => x.Id == s.Id));

            return emps;
        }

        public async Task<int> InsertEmployee(Employee e)
        {
            var employeeQuery = "Insert into Employees (FirstName,LastName,Email) VALUES (@FirstName,@LastName,@Email)";

            using var connection = _employeeDBContext.CreateConnection();
            var newItem = await connection.ExecuteAsync(employeeQuery, e);
            e.Id = newItem;
            return newItem;
        }
    }
}
