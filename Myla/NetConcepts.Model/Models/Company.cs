using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConcepts.Model.Models
{
    internal class Company
    {
        public IList<Employee> Employees;

        public string Name { get; set; }

        public Company(string name)
        {
            Name = name;
            Employees = new List<Employee>();
            Employees.Add(new Employee("First Emp", "1"));
        }
    }
}
