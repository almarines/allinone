using Core;
using Core.Models;
using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests
{
    public class EmployeeControllerTests
    {
        //[Fact]
        [Theory]
        [InlineData("First", "Last", "email@y.com")]
        public async Task InsertEmployee_Tests(string firstname, string lastname, string email)
        {
            // Arrange
            var namingService = Substitute.For<INamingService>();
            namingService.IsValid(Arg.Any<string>()).Returns(true);

            var mailService = Substitute.For<IMailService>();
            mailService.IsValid(Arg.Any<string>()).Returns(true);

            var mockRepo = Substitute.For<IEmployeeRepository>();
            //var list = new List<Employee>();
            //mockRepo.InsertEmployee(Arg.Any<Employee>()).Returns(s =>
            //{
            //    list.Add(s[0] as Employee);
            //    return 1;
            //});
            mockRepo.InsertEmployee(Arg.Any<Employee>()).Returns(1);
            var controller = new EmployeeController(mockRepo, mailService, namingService);

            // Act
            var result = await controller.InsertEmployee(new EmployeeDto { FirstName = firstname, LastName = lastname, Email = email  });
            var r = result as OkObjectResult;

            // Assert
            //Assert.Single(list);
            Assert.NotNull(result);
            Assert.Equal(200, r.StatusCode);
            await mockRepo.Received().InsertEmployee(Arg.Any<Employee>());
            namingService.Received().IsValid(Arg.Any<string>());
            mailService.Received().IsValid(Arg.Any<string>());
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("First", "Last", "")]
        [InlineData("First", "", "")]
        [InlineData("", "Last", "")]
        [InlineData("", "Last", "email")]
        [InlineData("First", "Last", "email")]
        public async Task InsertEmployee_Failed_Tests(string firstname, string lastname, string email)
        {
            // Arrange
            var namingService = Substitute.For<INamingService>();
            namingService.IsValid(Arg.Any<string>()).Returns(false);

            var mailService = Substitute.For<IMailService>();
            mailService.IsValid(Arg.Any<string>()).Returns(false);

            var mockRepo = Substitute.For<IEmployeeRepository>();
            var list = new List<Employee>();
            mockRepo.InsertEmployee(Arg.Any<Employee>()).Returns(s =>
            {
                list.Add(s[0] as Employee);
                return 1;
            });
            var controller = new EmployeeController(mockRepo, mailService, namingService);

            // Act
            Func<Task> action = async () => await controller.InsertEmployee(new EmployeeDto { FirstName = firstname, LastName = lastname, Email = email });

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(action);
        }
        [Fact]
        public async Task GetEmployee_Tests()
        {
            // Arrange
            var namingService = Substitute.For<INamingService>();
            var mailService = Substitute.For<IMailService>();
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var list = new List<Employee>() { new FullTimeEmployee() { FirstName = "First", LastName = "Last" } };
            mockRepo.GetAll().Returns(s =>
            {
                return list;
            });

            var controller = new EmployeeController(mockRepo, mailService, namingService);

            // Act
            var result = await controller.GetAll();
            var r = result as OkObjectResult;
            var actualResult = r.Value as IEnumerable<Employee>;

            // Assert
            Assert.NotEmpty(actualResult);
            Assert.NotNull(result);
            Assert.NotNull(r);
            Assert.Equal(200, r.StatusCode);
            Assert.Equal(list, actualResult);
            await mockRepo.Received().GetAll();
        }
    }
}
