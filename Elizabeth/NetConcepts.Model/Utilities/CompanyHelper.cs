using NetConcepts.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConcepts.Model.Utilities
{
    internal static class CompanyHelper
    {
        public static async Task<Company> CreateCompany(string companyName, int noOfEmp)
        {
            var c = new Company(companyName);
            await Task.Delay(1);
            for (int i = 1; i < noOfEmp; i++)
            { 
                c.Employees.Add(new Employee($"Emp {i}", i.ToString()));
            }

            return c;
        }       
    }
}
