using EmployeeManagementApi.Application.Query;
using FluentValidation;
using System;
using System.Linq;

namespace EmployeeManagementApi.Application.Validation
{
    public class GetEmployeeByNameQueryValidator : AbstractValidator<GetEmployeeByNameQuery>
    {
        public GetEmployeeByNameQueryValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().NotNull().WithMessage("First Name is Empty");
        }
    }
}
