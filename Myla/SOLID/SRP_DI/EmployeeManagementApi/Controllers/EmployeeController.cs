using Core.Contracts;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMailService _mailService;
        private readonly INamingService _namingService;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeRepository employeeRepository,
            IMailService mailService, INamingService namingService)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mailService = mailService;
            _namingService = namingService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<Employee>();
            //using (var connection = new SqlConnection(this.dbOptions.Value.PathToDB))
            //{
            //    connection.Open();
            //    var employeeQuery = "Select * from Employees";
            //    var cmd = new SqlCommand(employeeQuery, connection);

            //    var read = cmd.ExecuteReader();
            //    while (read.Read())
            //    {
            //        var e = new FullTimeEmployee();
            //        e.Id = (int)read["id"];
            //        e.FirstName = (string)read["FirstName"];
            //        e.LastName = (string)read["LastName"];
            //        e.Email = (string)read["Email"];
            //        result.Add(e);
            //    }               
            //}

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

            var e = new FullTimeEmployee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email };
            var result = ""; // await _employeeRepository.InsertEmployee(e);

            // send mail to employee
            await _mailService.SendMail(e.Email, "Welcome Mail", "Welcome to Danaher");

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
