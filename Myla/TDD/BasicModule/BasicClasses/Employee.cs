using System;
using System.Collections.Generic;

namespace BasicModule.BasicClasses
{
    public class Employee
    {
               public IList<Employee> Employees;

        public string Name { get; }

        public Guid Id { get; }

        public int EmpCode { get; }

        public Employee(string name, int code)
        {
            Name = name;
            EmpCode = code;
            Id = Guid.NewGuid();
        }

        //public override string ToString()
        //{
        //    return string.Concat(EmpCode, ":", Name);
        //}

        public void Add(Employee e)
        {
            if (string.IsNullOrEmpty(e.Name))
            {
                throw new InvalidOperationException();
            }

            Employees.Add(e);
        }

    }

   

    internal class FullTimeEmp : Employee
    {
        public FullTimeEmp(string name, int code) : base(name, code)
        {

        }
    }

    internal class PartTimeEmp : Employee
    {
        public PartTimeEmp(string name, int code) : base(name, code)
        {

        }
    }
}
