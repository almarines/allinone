using Core;
using EmployeeManagementApi.Application.CommandHandlers;
using EmployeeManagementApi.Application.Commands;
using EmployeeManagementApi.Application.Validation;
using FluentValidation;
using MailService;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests.Application.Validation {
	public class InsertEmployeeCommandValidatorTests {
		[Theory]
		[InlineData(false, false, false, 3)]
		[InlineData(false, false, true, 2)]
		//[InlineData(false, true, true, 1)] // Fails
		//[InlineData(false, true, false, 2)]// Fails
		//[InlineData(true, false, true, 1)]// Fails
		[InlineData(true, true, false, 1)]
		public void InsertEmployee_Test_InvalidValidations(bool firstNameValid, bool lastNameValid, bool mailValid, int expectedErrorCount) {
			// Arrange
			var namingService = Substitute.For<INamingService>();
			var mailingService = Substitute.For<IMailService>();

			namingService.IsValid(Arg.Any<string>()).Returns(firstNameValid);
			namingService.IsValid(Arg.Any<string>()).Returns(lastNameValid);
			mailingService.IsValid(Arg.Any<string>()).Returns(mailValid);

			var validator = new InsertEmployeeCommandValidator(namingService, mailingService);

			// Act
			var result = validator.Validate(new InsertEmployeCommand());


			// Assert
			namingService.Received().IsValid(Arg.Any<string>());
			mailingService.Received().IsValid(Arg.Any<string>());
			Assert.True(expectedErrorCount == result.Errors.Count, $"Actual Error count: {result.Errors.Count} | Expected: {expectedErrorCount}");
		}
	}
}
