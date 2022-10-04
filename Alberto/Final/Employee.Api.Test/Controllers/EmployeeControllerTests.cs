using Core.Contracts;
using EmployeeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async void GetAll_Test()
        {
            // Arrange
            var item = SetUp();
            var controller = item.Item1;
            var mockEmpRepo = item.Item2;
            mockEmpRepo.GetAll().Returns(new List<Core.Models.Employee>() { new Core.Models.Employee() });

            // Act
            var list = await controller.GetAll();
            var result = list as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Core.Models.Employee>>(result.Value);
            await mockEmpRepo.Received().GetAll();
        }

        private static (EmployeeController, IEmployeeRepository) SetUp()
        {
            var mockLogger = Substitute.For<ILogger<EmployeeController>>();
            var mockEmpRepo = Substitute.For<IEmployeeRepository>();
            var mockMail = Substitute.For<IMailService>();
            var controller = new EmployeeController(mockLogger, mockEmpRepo, mockMail);

            return (controller, mockEmpRepo);
        }
    }
}
