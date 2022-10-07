using Core;
using Core.Models;
using EmployeeManagementApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace EmployeeManagementApi.Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async void InsertEmployee_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            mockRepo.InsertEmployee(Arg.Any<Employee>()).Returns(1);

            var namingService = Substitute.For<INamingService>();
            namingService.IsValid(Arg.Any<string>()).Returns(true);

            var mailService = Substitute.For<IMailService>();
            mailService.IsValid(Arg.Any<string>()).Returns(true);


            var controller = new EmployeeController(mockRepo, namingService, mailService);

            // Act
            var result = await controller.InsertEmployee(new Dto.EmployeeDto() { FirstName = "fist", LastName = "last", Email = "a@gmail.com" });
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(okResult.Value);
            await mockRepo.Received().InsertEmployee(Arg.Any<Employee>());
        }
    }
}
