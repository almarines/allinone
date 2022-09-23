using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async void GetEmployee_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var list = new List<EmployeeManagementApi.Models.Employee>() { new EmployeeManagementApi.Models.Employee() };
            mockRepo.GetAll().Returns(s =>
            {
                return list;
            });

            var controller = new EmployeeController(mockRepo);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.Same(list, result);
        }

        [Fact]
        public void GetEmployeeById_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var employee = new EmployeeManagementApi.Models.Employee();
            mockRepo.Get(1).Returns(s =>
            {
                return employee;
            });

            var controller = new EmployeeController(mockRepo);

            // Act
            var result = controller.GetEmployeeById(1);
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void InsertEmployee_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var controller = new EmployeeController(mockRepo);

            // Act
            var result = controller.InsertEmployee(new EmployeeDto() { FirstName = "Name" });
            var okResult = result as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void InsertEmployee_Exception_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var controller = new EmployeeController(mockRepo);

            // Act
            Action action = () => controller.InsertEmployee(new EmployeeDto());

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
