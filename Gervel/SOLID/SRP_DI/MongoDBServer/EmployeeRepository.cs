using Core;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
			FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(m => m.Id, id);
			IAsyncCursor<Employee> results = await employeeDBContext.Employees.FindAsync(filter);
			return await results.FirstOrDefaultAsync();
		}

		public async Task<Employee> GetByName(string name) {
			FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(m => m.FirstName, name);
			IAsyncCursor<Employee> results = await employeeDBContext.Employees.FindAsync(filter);
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
				await employeeDBContext.Employees.InsertOneAsync(employee);
				return 1;
			} catch {
				return 0;
			}
		}
	}
}
