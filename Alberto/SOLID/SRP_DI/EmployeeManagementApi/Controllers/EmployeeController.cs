using Core;
using Core.Contracts;
using Core.Models;
using EmployeeManagementApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly INamingService _namingService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMailService _mailService;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IEmployeeRepository employeeRepo, INamingService namingService,
                                            IMailService mailService)
        {
            _namingService = namingService;
            _employeeRepository = employeeRepo;
            _mailService = mailService;
            //this.logger = logger;
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
            if (!_namingService.IsValid(id.ToString()))
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
            if (!_namingService.IsValidNumber(id))
            {
                throw new InvalidOperationException();
            }

            var result = await _employeeRepository.GetInsurance(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> InsertEmployee(EmployeeDto employeeDto)
        {
            if (!_namingService.IsValid(employeeDto.FirstName) || !_namingService.IsValid(employeeDto.LastName))
            {
                throw new InvalidOperationException();
            }

            if (!_mailService.IsValid(employeeDto.Email))
            {
                throw new InvalidOperationException();
            }

            var result = await _employeeRepository.InsertEmployee(new FullTimeEmployee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email });

            // send mail to finance / insurance team           
            await _mailService.SendMail("finance@xyz.com", "Welcome", "Welcome To xyz");

            return Ok(result);
        }       
    }

   
}
