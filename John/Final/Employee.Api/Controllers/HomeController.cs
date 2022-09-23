using Core.Contracts;
using Core.Models;
using EmployeeManagementApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new List<Core.Models.Employee>());
        }
    }
}
