using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnBoarding.api.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Department> Departments { get; set;}


        //public bool HasAccess(string departmentName)
        //{
        //    return Departments.FirstOrDefault(s => s.Name == departmentName) != null;
        //}
    }

    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
