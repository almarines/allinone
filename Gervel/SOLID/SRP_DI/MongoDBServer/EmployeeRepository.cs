using Core;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace DatabaseCore {
	public class EmployeeRepository : IEmployeeRepository {
		private readonly EmployeeDBContext employeeDBContext;
		private readonly IMailService mailService;

		public EmployeeRepository(EmployeeDBContext employeeDBContext, IMailService mailService) {
			this.employeeDBContext = employeeDBContext;
			this.mailService = mailService;
		}

		public async Task<IEnumerable<Employee>> GetAll() {
			var result = await employeeDBContext.Employees.FindAsync(_ => true);
			return result.ToList();

		}

		public async Task<Employee> GetById(int id) {
			FilterDefinition<FullTimeEmployee> filter = Builders<FullTimeEmployee>.Filter.Eq(m => m.Id, id);
			IAsyncCursor<FullTimeEmployee> results = await employeeDBContext.Employees.FindAsync(filter);
			return await results.FirstOrDefaultAsync();
		}

		public async Task<Employee> GetByName(string name) {
			FilterDefinition<FullTimeEmployee> filter = Builders<FullTimeEmployee>.Filter.Eq(m => m.FirstName, name);
			IAsyncCursor<FullTimeEmployee> results = await employeeDBContext.Employees.FindAsync(filter);
			return await results.FirstOrDefaultAsync();
		}

		public async Task<int> GetSalary(int id) {
			var emp = await GetById(id);
			return emp.GetSalary();
		}

		public async Task<string> GetInsurance(int id) {
			var emp = await GetById(id);
			return emp.GetInsurance();
		}

		public async Task<int> InsertEmployee(Employee employee) {
			try {
				var allEmployees = await employeeDBContext.Employees.FindAsync(_ => true);
				var count = allEmployees.ToList().Count;

				employee.Id = count + 1;

				await employeeDBContext.Employees.InsertOneAsync(employee as FullTimeEmployee);
				return 1;
			} catch (Exception ex) {
				Console.WriteLine($"[ERROR] InsertEmployee() {ex.Message}");
				return 0;
			}
		}
	}
}
