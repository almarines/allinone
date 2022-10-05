using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories;
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

        //[Theory]
        //[InlineData("","","")]
        //[InlineData("Bong", "Moambing", "Alberto.Moambing")]
        [Fact]

        public async Task InsertEmployee_Tests()
        {

            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            mockRepo.InsertEmployee(Arg.Any<Employee>()).Returns(1);

            var controller = new EmployeeController(mockRepo);

            EmployeeDto mockEmployee = new EmployeeDto
            {
                FirstName = "firtname",
                LastName = "lastname",
                Email = "@email.com"
            };

            // Act            
            var result = await controller.InsertEmployee(mockEmployee);
            var okResult = result as OkObjectResult;
            
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(okResult.Value);
            //await mockRepo.Received().InsertEmployee(Arg.Any<Employee>());
           // Assert.ThrowsAnyAsync<InvalidOperationException>(result);
        }

        [Fact]
        public async Task EmployeeList_Tests()
        {
            var mockRepo = Substitute.For<IEmployeeRepository>();
            
            var mockEmployees = new List<Employee>()
            {
                new FullTimeEmployee()
                {
                   FirstName = "firtname",
                   LastName = "lastname",
                     Email = "@email.com"
                }
                
            };
            mockRepo.GetAll().Returns(s => { return mockEmployees; });

            var controller = new EmployeeController(mockRepo);
            // Act            
            var result = await controller.GetAll();
            var okResult = result as OkObjectResult;
            var resultValue = okResult.Value as IEnumerable<Employee>;


            //Assert
            Assert.NotNull(resultValue);
            Assert.Single(resultValue);
            

        }

    }
}
