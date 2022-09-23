using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {           
            return await employeeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var employee = await employeeRepository.Get(Id);
			return Ok(employee);
        }

        [HttpPost]
        public IActionResult InsertEmployee(EmployeeDto employeeDto)
        {
            if(string.IsNullOrEmpty(employeeDto.FirstName))
            {
                throw new InvalidOperationException();
            }

            var e = new Employee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName };
            var result = employeeRepository.InsertEmployee(e);

            return Ok(result);
        }
    }
}
