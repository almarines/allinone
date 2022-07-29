﻿using NetConcepts.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace NetConcepts.Model.Contracts
{
    internal interface ICompanyService
    {
        void AddEmployee(Employee employee);
        void AddEmployee(string name, string code);
        Employee GetEmployee(Guid id);

        IEnumerable<Employee> GetEmployees();
        void RemoveEmployee(Guid id);
    }

    internal class CompanyService : ICompanyService
    {
        private readonly Company company;

        private static int count;

        public CompanyService(Company c)
        {
            this.company = c;
        }

        public Employee GetEmployee(Guid id)
        {
            return this.company.Employees.FirstOrDefault(s => s.Id == id);
        }

        public void AddEmployee(string name, string code)
        {
            this.company.Employees.Add(new Employee(name, code));
        }

        public void RemoveEmployee(Guid id)
        {
            var emp = GetEmployee(id);
            if (emp != null)
            {
                this.company.Employees.Remove(emp);
            }
        }

        public void AddEmployee(Employee employee)
        {
            this.company.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.company.Employees;
        }
    }
}
