using Core;
using EmployeeManagementApi.Application.Commands;
using EmployeeManagementApi.Application.Query;
using EmployeeManagementApi.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IMediator _mediator;

        public EmployeeController(IMailService mailService, IMediator mediator)
        {
            _mailService = mailService;
            _mediator = mediator;
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
			var result = await _mediator.Send(new GetEmployeeByNameQuery() { FirstName = firstName});
			return Ok(result);
        }

        [HttpGet]
        [Route("fullsalary")]
        public async Task<IActionResult> GetSalary(int id)
        {
			var result = await _mediator.Send(new GetEmployeeSalaryQuery() { EmployeeId = id });
			return Ok(result);
        }

        [HttpGet]
        [Route("insurance")]
        public async Task<IActionResult> GetInsurance(int id)
        {
			var result = await _mediator.Send(new GetEmployeeInsuranceQuery() { EmployeeId = id });
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
