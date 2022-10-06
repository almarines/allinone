using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using SMTPMailServiceLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SMTPMailServiceLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
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

            //await mediator.Send(InsertEmployeeCommand() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email } )
            var result = await _employeeRepository.InsertEmployee(new FullTimeEmployee() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName, Email = employeeDto.Email });

            // send mail to finance / insurance team           
            await _mailService.SendMail("finance@xyz.com", "Welcome", "Welcome To xyz");

            return Ok(result);
        }
    }


}
