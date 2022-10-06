using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SMTPMailService;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMailService _mailService;
        private readonly INamingService _namingService;

        public EmployeeController(IEmployeeRepository employeeRepo, IMailService mailService, INamingService namingService)
        {
            _namingService = namingService;
            _employeeRepository = employeeRepo;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("firstname")]
        public async Task<IActionResult> GetByName(string firstName)
        {
            if (!_namingService.IsValid(firstName))
            {
                throw new InvalidOperationException();
            }

            var result = await _employeeRepository.GetByName(firstName);
            return Ok(result);
        }

        [HttpGet]
        [Route("fullsalary")]
        public async Task<IActionResult> GetSalary(int id)
        {
            if (!_namingService.IsValid(id))
            {
                throw new InvalidOperationException();
            }

            var result = await _employeeRepository.GetSalary(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("insurance")]
        public async Task<IActionResult> GetInsurance(int id)
        {
            if (!_namingService.IsValid(id))
            {
                throw new InvalidOperationException();
            }

            var result = await _employeeRepository.GetInsurance(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> InsertEmployee(EmployeeDto employeeDto)
        {
            if (!_namingService.IsValid(employeeDto.FirstName) || !_namingService.IsValid(employeeDto.LastName))
            {
                throw new InvalidOperationException();
            }

            if (!_mailService.IsValid(employeeDto.Email))
            {
                throw new InvalidOperationException();
            }

            var result = _employeeRepository.InsertEmployee(new FullTimeEmployee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email });

            // send mail to finance / insurance team
            await _mailService.SendMail("finance@danaher.com", "Welcome", "Welcome To Danaher");

            return Ok(result);
        }

        private bool ExecuteQueryWithNoResult(SqlConnection connection, string query, params object[] paramList)
        {
            var cmd = new SqlCommand(query, connection);

            var paramCount = 0;
            foreach (var param in paramList)
            {
                var myParam = new SqlParameter(string.Format("@{0}", ++paramCount), SqlDbType.VarChar)
                {
                    Value = param
                };
                cmd.Parameters.Add(myParam);
            }

            // return a Sql data reader that returns number of impacted lines
            return cmd.ExecuteNonQuery() > 0;
        }
    }

   
}
