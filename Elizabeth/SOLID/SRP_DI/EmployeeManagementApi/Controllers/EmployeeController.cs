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
        private readonly EmployeeDBContext employeeDBContext;
        private readonly IOptions<DbConfig> dbOptions;
        private readonly string dbPath;
        private readonly NamingService namingService;

        public EmployeeController(string dbPath, NamingService namingService/*EmployeeDBContext employeeDBContext, IOptions<DbConfig> dbOptions*/)
        {
            this.dbPath = dbPath;
            //this.employeeDBContext = employeeDBContext;
            //this.dbOptions = dbOptions;
            this.namingService = namingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<Employee>();
            using (var connection = new SqlConnection(this.dbOptions.Value.PathToDB))
            {
                connection.Open();
                var employeeQuery = "Select * from Employees";
                var cmd = new SqlCommand(employeeQuery, connection);

                var read = cmd.ExecuteReader();
                while (read.Read())
                {
                    var e = new FullTimeEmployee();
                    e.Id = (int)read["id"];
                    e.FirstName = (string)read["FirstName"];
                    e.LastName = (string)read["LastName"];
                    e.Email = (string)read["Email"];
                    result.Add(e);
                }               
            }

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

            var result = employeeDBContext.Add(new EmployeeDto()); //true/*false*/;
            //using (var connection = new SqlConnection(dbPath/*this.dbOptions.Value.PathToDB*/))
            //{
            //    connection.Open();
            //    var employeeQuery = "Insert into Employees (FirstName,LastName,Email,BasicPay,HRA,Bonus,IsFullTimeEmployee, EmpType) VALUES (@1,@2,@3,@4,@5,@6, @7, @8)";

            //    result = ExecuteQueryWithNoResult(connection, employeeQuery, employeeDto.FirstName, employeeDto.LastName, employeeDto.Email, 1, 1, 1, false, 1);
            //}

            //// send mail to finance / insurance team
            await mailService.SendMail("finance@danaher.com", "Welcome", "Welcome To Danaher");

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
