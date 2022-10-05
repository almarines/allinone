using EmployeeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Managers
{
    public interface IEmployeeRepository
    {
        Task<int> InsertEmployee(Employee employee);
        Task<List<Employee>> GetAll();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext employeeDBContext;

        public EmployeeRepository(EmployeeDBContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
           employeeDBContext.Employees.Add(employee);
           return await employeeDBContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await employeeDBContext.Employees.ToListAsync();
        }
    }
}
