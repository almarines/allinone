using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        //private readonly LiteDBContext employeeDBContext;

        //public EmployeeController(LiteDBContext employeeDBContext)
        //{
        //    this.employeeDBContext = employeeDBContext;
        //}

        [HttpGet]
        public IActionResult GetAll()
        {           
            return Ok(LiteDBContext.Instance.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            return Ok(LiteDBContext.Instance.GetEmployeeById(Id));
        }

        [HttpPost]
        public IActionResult InsertEmployee(EmployeeDto employeeDto)
        {
            if(string.IsNullOrEmpty(employeeDto.FirstName))
            {
                throw new InvalidOperationException();
            }

            var e = new Employee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName };
            var result = LiteDBContext.Instance.InsertEmployee(e);
            //await employeeDBContext.SaveChangesAsync();

            // send mail to finance / insurance team
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);

            return Ok(result.AsInt32);
        }
    }
}
