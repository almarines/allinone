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
        private readonly IMailService _mailService;
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IMailService mailService, IMediator mediator)
        {
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
        [Route("firstname/{firstName}")]
        public async Task<IActionResult> GetByName(string firstName)
        {
            var result = await _mediator.Send(new GetByNameQuery { FirstName = firstName });
            return Ok(result);
        }

        [HttpGet]
        [Route("fullsalary/{id}")]
        public async Task<IActionResult> GetSalary(int id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });
            return Ok(result.GetSalary());
        }

        [HttpGet]
        [Route("insurance/{id}")]
        public async Task<IActionResult> GetInsurance(int id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });
            return Ok(result.GetInsurance());
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
