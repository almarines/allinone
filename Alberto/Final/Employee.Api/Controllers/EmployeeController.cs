using Core.Contracts;
using Core.Models;
using EmployeeManagementApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EmployeeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMailService _mailService;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeRepository employeeRepository,
            IMailService mailService)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(EmployeeDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.Email))
            {
                throw new InvalidOperationException();
            }

            var e = new Employee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email };
            e.Salary = new Payment() { BasicPay = 10000, HRA = 2000, Bonus = 50000 };
            e.Insurance = new Insurance { Name = "HDFC Ergo", Amount = 500000 };

            var result = await _employeeRepository.InsertEmployee(e);

            // send mail to employee
            await _mailService.SendMail(e.Email, "Welcome Mail", "Welcome to Danaher");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException();
            }

            var result = await _employeeRepository.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
