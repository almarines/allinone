using Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Core.Models;

namespace DatabaseCore {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly LiteDBContext employeeDBContext;
        private readonly IMailService mailService;

        public EmployeeRepository(LiteDBContext employeeDBContext, IMailService mailService) {
            this.employeeDBContext = employeeDBContext;
            this.mailService = mailService;
        }

        public async Task<IEnumerable<Employee>> GetAll() {
            return await Task.FromResult(employeeDBContext.GetAllEmployees());
        }

        public async Task<Employee> GetById(int id) {
			return await Task.FromResult(employeeDBContext.GetEmployeeById(id));
        }

        public async Task<Employee> GetByName(string name) {
            var employees = employeeDBContext.GetAllEmployees();
			return await Task.FromResult(employees.FirstOrDefault(s => s.FirstName == name));
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
			return await Task.FromResult(employeeDBContext.InsertEmployee(employee));
        }
    }
}
