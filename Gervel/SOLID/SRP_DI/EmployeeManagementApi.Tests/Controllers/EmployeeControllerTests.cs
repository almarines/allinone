using Core;
using Core.Models;
using EmployeeManagementApi.Application.Commands;
using EmployeeManagementApi.Application.Query;
using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests {
	public class EmployeeControllerTests {

		[Fact]
		public async Task InsertEmployee_Test_ValidCase() {
			// Arrange
			var mediator = Substitute.For<IMediator>();
			var mailingService = Substitute.For<IMailService>();

			mediator.Send(Arg.Any<InsertEmployeCommand>()).Returns(1);
			mailingService.IsValid(Arg.Any<string>()).Returns(true);

			var controller = new EmployeeController(mailingService, mediator);

			EmployeeDto mockEmployee = new EmployeeDto {
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
			await mediator.Received().Send(Arg.Any<InsertEmployeCommand>());
			await mailingService.Received().SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
		}

		[Fact]
		public async Task InsertEmployee_Test_InsertError() {
			// Arrange
			var mediator = Substitute.For<IMediator>();
			var mailingService = Substitute.For<IMailService>();

			mediator.Send(Arg.Any<InsertEmployeCommand>()).Returns(0);
			mailingService.IsValid(Arg.Any<string>()).Returns(true);

			var controller = new EmployeeController(mailingService, mediator);

			EmployeeDto mockEmployee = new EmployeeDto {
				FirstName = "First",
				LastName = "Last",
				Email = "tester@kyoceraa.com"
			};

			// Act
			var insertOperationResult = await controller.InsertEmployee(mockEmployee);
			var okResult = insertOperationResult as OkObjectResult;
			var actualResult = (int)okResult.Value;

			// Assert
			var expectedResult = 0;

			Assert.NotNull(insertOperationResult);

			Assert.Equal(expectedResult, actualResult);
			await mediator.Received().Send(Arg.Any<InsertEmployeCommand>());
			await mailingService.Received().SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
		}

		[Fact]
		public async Task GetAllEmployee_Test_ValidCase() {
			// Arrange
			var mockList = new List<Employee>
			{
				new FullTimeEmployee { FirstName = "First", LastName = "Last Name", Email = "test.1@kyocera.com" }
			};

			var mediator = Substitute.For<IMediator>();
			var mailingService = Substitute.For<IMailService>();

			mediator.Send(Arg.Any<GetAllEmployeeQuery>()).Returns(mockList);

			var controller = new EmployeeController(mailingService, mediator);

			var getAllOperationResult = await controller.GetAll();
			var okResult = getAllOperationResult as OkObjectResult;
			var actualResult = okResult.Value as IEnumerable<Employee>;

			// Assert
			Assert.NotNull(getAllOperationResult);
			Assert.NotNull(okResult);
			Assert.NotNull(actualResult);
			Assert.NotEmpty(actualResult);
			Assert.Same(mockList, actualResult);
			await mediator.Received().Send(Arg.Any<GetAllEmployeeQuery>());
		}

		[Fact]
		public async Task GetAllEmployee_Test_EmptyList() {
			// Arrange
			var mockList = new List<Employee>();

			var mediator = Substitute.For<IMediator>();
			var mailingService = Substitute.For<IMailService>();

			mediator.Send(Arg.Any<GetAllEmployeeQuery>()).Returns(mockList);

			var controller = new EmployeeController(mailingService, mediator);

			var getAllOperationResult = await controller.GetAll();
			var okResult = getAllOperationResult as OkObjectResult;
			var actualResult = okResult.Value as IEnumerable<Employee>;

			// Assert
			Assert.NotNull(getAllOperationResult);
			Assert.NotNull(okResult);
			Assert.NotNull(actualResult);
			Assert.Empty(actualResult);
			await mediator.Received().Send(Arg.Any<GetAllEmployeeQuery>());
		}
	}
}
