using Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Core.Models;
using DataBaseCore.DBContext;
using MongoDB.Driver;

namespace DataBaseCore
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext employeeDBContext;

        public EmployeeRepository(EmployeeDBContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employeeDBContext.GetAllAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(m => m.Id, id);
            IAsyncCursor<Employee> results = await employeeDBContext.Employees.FindAsync(filter);
            return await results.FirstOrDefaultAsync();
        }

        public async Task<Employee> GetByName(string name)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("FirstName", name);
            return await employeeDBContext.GetByFilterAsync(filter);
        }

        public async Task<int> GetSalary(int id)
        {
            var emp = await GetById(id);
            return emp.GetSalary();
        }

        public async Task<string> GetInsurance(int id)
        {
            var emp = await GetById(id);
            return emp.GetInsurance();
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            await employeeDBContext.CreateAsync(employee);
            return 1;
        }
    }
}