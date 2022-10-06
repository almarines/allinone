using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SMTPMailService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests
{
    public class EmployeeControllerTests
    {
        //[Theory]
        //[InlineData("", "", "")]
        //[InlineData("FirstName", "LastName", "")]
        //[InlineData("FirstName", "", "")]
        //[InlineData("", "Last", "")]
        //[InlineData("", "Last", "Email")]
        //[InlineData("FirstName", "Last", "Email")]
        //[InlineData("FirstName", "Last", "Email@email.com")]
        //public async Task InsertEmployee_Test_ValidateFirstName(string firstName, string lastName, string email)
        //{
        //    // Arrange
        //    var controller = new EmployeeController(Arg.Any<string>());

        //    var employee = new EmployeeDto() { 
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Email = email
        //    };

        //    // Act
        //    Func<Task> action = async () => await controller.InsertEmployee(employee);

        //    // Assert
        //    await Assert.ThrowsAsync<InvalidOperationException>(action);
        //}


        [Fact]
        public async Task InsertEmployee_Test()
        {
            // Arrange
            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            mockEmployeeRepository.InsertEmployee(Arg.Any<Employee>()).Returns(1);

            var namingservice = Substitute.For<INamingService>();
            namingservice.IsValid(Arg.Any<string>()).Returns(true);

            var mailService = Substitute.For<IMailService>();
            mailService.IsValid(Arg.Any<string>()).Returns(true);

            var controller = new EmployeeController(mockEmployeeRepository, mailService, namingservice);

            // Act
            var result = await controller.InsertEmployee(
                new EmployeeDto
                {
                    FirstName = "John",
                    LastName = "Mayordo",
                    Email = "john.mayordo@kyocera.com"
                });

            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(okResult.Value);
            await mockEmployeeRepository.Received().InsertEmployee(Arg.Any<Employee>());
            namingservice.Received().IsValid(Arg.Any<string>());
            mailService.Received().IsValid(Arg.Any<string>());
        }

        [Fact]
        public async Task GetAllEmployee_Test()
        {
            // Arrange
            var namingservice = Substitute.For<INamingService>();
            namingservice.IsValid(Arg.Any<string>()).Returns(true);

            var mailService = Substitute.For<IMailService>();
            mailService.IsValid(Arg.Any<string>()).Returns(true);

            var mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            var employeeList = new List<Employee>()
            {
               new FullTimeEmployee()
               {
                   FirstName = "John",
                   LastName = "Test",
                   Email =  "test@email.com"
               }
            };

            mockEmployeeRepository.GetAll().Returns(s =>
            {
                return employeeList;
            });

            var controller = new EmployeeController(mockEmployeeRepository, mailService, namingservice);

            // Act
            var result = await controller.GetAll();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as IEnumerable<Employee>;

            // Assert
            Assert.NotEmpty(value);
            Assert.Single(value);
            Assert.NotNull(result);
            Assert.NotNull(okResult.Value);
            await mockEmployeeRepository.Received().GetAll();
            namingservice.Received().IsValid(Arg.Any<string>());
            mailService.Received().IsValid(Arg.Any<string>());
        }
    }
}
