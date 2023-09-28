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
    public class GetByIdEmployeeCommandValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdEmployeeCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().WithMessage("Id is Empty");
        }
    }
}
