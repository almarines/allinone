using EmployeeManagementApi.Application.Query;
using FluentValidation;
using System;
using System.Linq;

namespace EmployeeManagementApi.Application.Validation
{
    public class GetEmployeeSalaryQueryValidator : AbstractValidator<GetEmployeeSalaryQuery>
    {
        public GetEmployeeSalaryQueryValidator()
        {
            RuleFor(c => c.EmployeeId).NotEmpty().NotNull().WithMessage("Id (EmployeeId) is null");
        }
    }
}
