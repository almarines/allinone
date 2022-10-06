using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SMTPMailServiceLib;
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
        private readonly INamingService namingService;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMailService mailService;

        public EmployeeController(IEmployeeRepository employeeRepo, IMailService mailService, INamingService namingService)
        {
            this.namingService = namingService;
            employeeRepository = employeeRepo;
            this.mailService = mailService;
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
