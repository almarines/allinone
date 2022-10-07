using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using MailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class InsuranceController : ControllerBase
    //{
    //    private readonly NamingService _namingService;
    //    private readonly IEmployeeRepository _employeeRepository;
    //    private readonly SMTPMailService _mailService;

    //    public InsuranceController(IIsunranceRepo isunranceRepo)
    //    {

    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetAll()
    //    {
    //        var result = await isunranceRepo.GetAll();
    //        return Ok(result);
    //    }     
    //}   
}
