using System.Collections.Generic;

namespace NetConcepts.Model.Models {
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
