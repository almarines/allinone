using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConcepts.Model.Models
{
    internal class Employee
    {
        public string Name { get; }

        public Guid Id { get; }

        public string EmpCode { get; }

        public Employee(string name, string code)
        {
            Name = name;
            EmpCode = code;
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return string.Concat(EmpCode, ":", Name);
        }
    }
}
