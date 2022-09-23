using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Repositories;
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
        public async void InsertEmployee_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            EmployeeDto employeeDto = new EmployeeDto();
            var e = new EmployeeDto() { FirstName = employeeDto.FirstName, LastName = employeeDto.LastName };

            var controller = new EmployeeController(mockRepo);

            // Act
            var result = await controller.InsertEmployee(e);
            var r = result as OkObjectResult;

            // Assert
            Assert.Same(e, r);
        }
    }
}
