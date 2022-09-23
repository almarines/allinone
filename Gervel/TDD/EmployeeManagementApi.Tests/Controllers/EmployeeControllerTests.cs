using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Linq;
using System.Linq.Expressions;
using EmployeeModel = EmployeeManagementApi.Models.Employee;

namespace Employee.Api.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async void GetEmployee_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var list = new List<EmployeeModel>() { 
                new EmployeeModel() { Id = 1  }
            };
            mockRepo.GetAll().Returns(s => list);

            var controller = new EmployeeController(mockRepo);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.Same(list, result);
        }

        [Fact]
        public async Task GetEmployeeById_Tests_FoundOne() {

			var mockRepo = Substitute.For<IEmployeeRepository>();
            EmployeeModel employee = new EmployeeModel() { Id = 1 };
            var list = new List<EmployeeModel>() {
                employee
            };
            mockRepo.Get(Arg.Any<int>()).Returns(s => list.First());

			var controller = new EmployeeController(mockRepo);

			var result = await controller.GetEmployeeById(1) as OkObjectResult;
            var employeeResult = result!.Value as EmployeeModel;

			Assert.NotNull(result);
            Assert.Same(employee, employeeResult);
            Assert.Equal(1, employeeResult!.Id);
		}

		[Fact]
		public async Task GetEmployeeById_Tests_FoundNothing() {

			var mockRepo = Substitute.For<IEmployeeRepository>();
			var controller = new EmployeeController(mockRepo);

			var result = await controller.GetEmployeeById(1) as OkObjectResult;
			var employeeResult = result!.Value as EmployeeModel;
            var employeeList = await mockRepo.GetAll();
			// var employeeListCount = employeeList.Count(); // Alternative

			Assert.Null(employeeResult);
            Assert.Empty(employeeList);
            // Assert.Equal(0, employeeListCount); // Alternative
		}

		[Fact]
        public async Task InsertEmployee_Test_PositiveCase() {
			var mockRepo = Substitute.For<IEmployeeRepository>();
			var controller = new EmployeeController(mockRepo);

			var insertResult = controller
                .InsertEmployee(new EmployeeDto { FirstName = "FirstName", LastName = "LastName" });

			Assert.NotNull(insertResult);
            await mockRepo.Received()
                .InsertEmployee(Arg.Is<EmployeeModel>(e => e.FirstName.Equals("FirstName") && e.LastName.Equals("LastName")));
		}

		[Fact]
		public async Task InsertEmployee_Test_NegativeCase() {
			var mockRepo = Substitute.For<IEmployeeRepository>();
			var controller = new EmployeeController(mockRepo);

			var insertOperation = () => controller.InsertEmployee(new EmployeeDto());

            await mockRepo.DidNotReceive().InsertEmployee(Arg.Any<EmployeeModel>());
            Assert.Throws<InvalidOperationException>(insertOperation);
		}
	}
}
