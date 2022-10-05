using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly NamingService namingService;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            namingService = new NamingService();
            employeeRepository = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await employeeRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(EmployeeDto employeeDto)
        {
            var mailService = new SMTPMailService();

            if (!namingService.IsValid(employeeDto.FirstName) || !namingService.IsValid(employeeDto.LastName))
            {
                throw new InvalidOperationException();
            }

            if (!mailService.IsValid(employeeDto.Email))
            {
                throw new InvalidOperationException();
            }

            var result = employeeRepository.InsertEmployee(new FullTimeEmployee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email });

            // send mail to finance / insurance team           
            await mailService.SendMail("finance@xyz.com", "Welcome", "Welcome To xyz");

            return Ok(result);
        }
    }

   
}
