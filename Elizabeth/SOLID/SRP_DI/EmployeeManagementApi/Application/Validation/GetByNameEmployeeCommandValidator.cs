using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using EmployeeManagementApi.Application.Commands;
using EmployeeManagementApi.Application.Query;
using FluentValidation;

namespace EmployeeManagementApi.Application.Validation
{
    public class GetByNameEmployeeCommandValidator : AbstractValidator<GetByNameQuery>
    {
        public GetByNameEmployeeCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().NotNull().WithMessage("First Name is Empty");
        }
    }
}
