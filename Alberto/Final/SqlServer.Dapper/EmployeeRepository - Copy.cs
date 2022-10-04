using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseCore.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DataBaseCore
{
    public interface IEmployeeDapperWrapper
    {
        Task<IEnumerable<T>> QueryAsync<T>(string q);

        Task<int> ExecuteAsync(string q);

        Task<int> ExecuteAsync(string query, object obj);
    }

    [ExcludeFromCodeCoverage]
    public class EmployeeDapperWrapper : IEmployeeDapperWrapper
    {
        private readonly EmployeeDBDapperContext employeeDBContext;

        public EmployeeDapperWrapper(EmployeeDBDapperContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using var connection = this.employeeDBContext.CreateConnection();
            return await connection.QueryAsync<T>(query);
        }

        public async Task<int> ExecuteAsync(string query)
        {
            using var connection = this.employeeDBContext.CreateConnection();
            return await connection.ExecuteAsync(query);
        }

        public async Task<int> ExecuteAsync(string query, object obj)
        {
            using var connection = this.employeeDBContext.CreateConnection();
            return await connection.ExecuteAsync(query, obj);
        }
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeDapperWrapper _employeeDapperWrapper;

        public EmployeeRepository(IEmployeeDapperWrapper employeeDapperWrapper)
        {
            _employeeDapperWrapper = employeeDapperWrapper;
        }

        public async Task<Employee> Get(int id)
        {
            var query = $"SELECT * FROM Employees WHERE Id = {id}";
            var emps = await _employeeDapperWrapper.QueryAsync<Employee>(query);

            //var payments = await connection.QueryFirstAsync<Payment>("select * from Payment where Id =@id", new { id });
            //emps.Salary = payments;

            return emps.First();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var query = "SELECT * FROM Employees";

            //using var connection = _employeeDBContext.CreateConnection();
            var emps = await _employeeDapperWrapper.QueryAsync<Employee>(query);

            //var payments = await connection.QueryAsync<Payment>("select * from Payment");
            //emps.ToList().ForEach(s => s.Salary = payments.FirstOrDefault(x => x.Id == s.Id));

            return emps;
        }

        public async Task<int> InsertEmployee(Employee e)
        {
            var employeeQuery = "Insert into Employees (FirstName,LastName,Email) VALUES (@FirstName,@LastName,@Email)";

            //using var connection = _employeeDBContext.CreateConnection();
            var newItem = await _employeeDapperWrapper.ExecuteAsync(employeeQuery, e);
            e.Id = newItem;
            return newItem;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employeeQuery = $"Delete from Employees WHERE Id = {id}";

            //using var connection = _employeeDBContext.CreateConnection();
            var newItem = await _employeeDapperWrapper.ExecuteAsync(employeeQuery);

            return newItem;
        }
    }

}
