using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using EmployeeManagementApi.Application.Commands;
using FluentValidation;

namespace EmployeeManagementApi.Application.Validation {
	public class InsertEmployeeCommandValidator : AbstractValidator<InsertEmployeCommand> {
		public InsertEmployeeCommandValidator(INamingService namingService, IMailService mailService) {
			RuleFor(c => c.FirstName).Custom((name, context) => {
				if (!namingService.IsValid(name)) {
					context.AddFailure("First Name is Empty");
				}
			});

			RuleFor(c => c.LastName).Custom((name, context) => {
				if (!namingService.IsValid(name)) {
					context.AddFailure("Last Name is Empty");
				}
			});

			RuleFor(c => c.Email).Custom((name, context) => {
				if (!mailService.IsValid(name)) {
					context.AddFailure("Email is invalid");
				}
			});
		}
	}

}
