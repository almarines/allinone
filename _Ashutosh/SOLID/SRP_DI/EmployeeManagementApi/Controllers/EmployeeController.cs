using Core;
using Core.Models;
using EmployeeManagementApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagementApi.Application.Commands;
using EmployeeManagementApi.Application.Query;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly INamingService _namingService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMailService _mailService;
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IEmployeeRepository employeeRepo, INamingService namingService,
                                            IMailService mailService, IMediator mediator)
        {
            _namingService = namingService;
            _employeeRepository = employeeRepo;
            _mailService = mailService;
            _mediator = mediator;
            //this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeeQuery());
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
        public async Task<ActionResult> InsertEmployee(EmployeeDto employeeDto)
        {
            var result = await _mediator.Send(new InsertEmployeCommand { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email });

            // send mail to finance / insurance team           
            await _mailService.SendMail("finance@xyz.com", "Welcome", "Welcome To xyz");

            return Ok(result);
        }       
    }

   
}
