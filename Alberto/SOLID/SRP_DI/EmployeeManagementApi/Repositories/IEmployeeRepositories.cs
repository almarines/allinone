using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EmployeeManagementApi.Repositories
{
    public interface IEmployeeRepositories
    {
       public bool InsertEmployee(Employee employee);
    }

    public class EmployeeRepositories : IEmployeeRepositories
    {
        private readonly EmployeeDBContext _employeeDBContext;

        public EmployeeRepositories(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }

        public bool InsertEmployee(Employee employee)
        {
            return true;
        }
    }

}
