using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
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
		[Theory]
		[InlineData("", "", "")]
		[InlineData("", "", "email@kyocera.com")]
		[InlineData("", "Last Name", "email@kyocera.com")]
		[InlineData("", "Last Name", "")]
		[InlineData("First Name", "", "email@kyocera.com")]
		[InlineData("First Name", "Last Name", "")]
		[InlineData("First Name", "Last Name", "email.com")]
		public void InsertEmployee_Test_InvalidValidations(string firstName, string lastName, string email)
		{
			// Arrange
			var employeeRepository = Substitute.For<IEmployeeRepository>();
			var controller = new EmployeeController(employeeRepository);

			EmployeeDto mockEmployee = new EmployeeDto { FirstName = firstName, LastName = lastName, Email = email };

			// Act
			Func<Task> insertOperation = async () => await controller.InsertEmployee(mockEmployee);

			// Assert
			Assert.ThrowsAsync<InvalidOperationException>(insertOperation);
		}

		[Fact]
		public async Task InsertEmployee_Test_ValidCase()
		{
			// Arrange
			var employeeRepository = Substitute.For<IEmployeeRepository>();
			employeeRepository.InsertEmployee(Arg.Any<FullTimeEmployee>()).Returns(1);
			var controller = new EmployeeController(employeeRepository);

			EmployeeDto mockEmployee = new EmployeeDto
			{
				FirstName = "First",
				LastName = "Last",
				Email = "tester@kyoceraa.com"
			};

			// Act
			var insertOperationResult = await controller.InsertEmployee(mockEmployee);
			var okResult = insertOperationResult as OkObjectResult;
			var actualResult = (int)okResult.Value;

			// Assert
			var expectedResult = 1;

			Assert.NotNull(insertOperationResult);

			Assert.Equal(expectedResult, actualResult);
			await employeeRepository.Received().InsertEmployee(Arg.Any<FullTimeEmployee>());
		}

		[Fact]
		public async Task GetAllEmployee_Test_ValidCase()
		{
			// Arrange
			var mockList = new List<Employee>
			{
				new FullTimeEmployee { FirstName = "First", LastName = "Last Name", Email = "test.1@kyocera.com" }
			};

			var employeeRepository = Substitute.For<IEmployeeRepository>();
			employeeRepository.GetAll().Returns(mockList);
			var controller = new EmployeeController(employeeRepository);

			var getAllOperationResult = await controller.GetAll();
			var okResult = getAllOperationResult as OkObjectResult;
			var actualResult = okResult.Value as IEnumerable<Employee>;

			// Assert
			Assert.NotNull(getAllOperationResult);
			Assert.NotNull(okResult);
			Assert.NotNull(actualResult);
			Assert.NotEmpty(actualResult);
			Assert.Same(mockList, actualResult);
			await employeeRepository.Received().GetAll();
		}
	}
}
