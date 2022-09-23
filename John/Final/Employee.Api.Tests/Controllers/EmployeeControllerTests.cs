using Core.Contracts;
using EmployeeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async void GetAll_Test()
        {
            //Arrange
            var item = Setup();
            var controller = item.Item1;
            var mockEmpRepo = item.Item2;
            mockEmpRepo.GetAll().Returns(new List<Core.Models.Employee>() { new Core.Models.Employee() });

            //Act
            var list = await controller.GetAll();
            var result = list as OkObjectResult;

            //Assert
            Assert.NotNull(result);
        }

        private static (EmployeeControllerTests, IEmployeeRepository) Setup()
        {
            var mockLogger = NSubstitute.Substitute.For<ILogger<EmployeeController>>();
            var mockEmpRepo = NSubstitute.Substitute.For<ILogger<IEmployeeRepository>>();
            var mockMail = NSubstitute.Substitute.For<ILogger<IMailService>>();
            var controller = new EmployeeController(mockLogger, (IEmployeeRepository)mockEmpRepo, (IMailService)mockMail);

            return (controller, mockEmpRepo);
        }
    }
}
