﻿using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseCore.DBContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseCore
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext employeeDBContext;

        public EmployeeRepository(EmployeeDBContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }

        public async Task<Employee> Get(int id)
        {
            return await employeeDBContext.Employees.Include(x => x.Salary).Include(x => x.Insurance).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employeeDBContext.Employees.Include(x => x.Salary).Include(x => x.Insurance).ToListAsync();
        }

        public async Task<int> InsertEmployee(Employee e)
        {
            employeeDBContext.Employees.Add(e);
            return await employeeDBContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var e = await Get(id);
            employeeDBContext.Employees.Remove(e);
            return await employeeDBContext.SaveChangesAsync();
        }
    }
}
