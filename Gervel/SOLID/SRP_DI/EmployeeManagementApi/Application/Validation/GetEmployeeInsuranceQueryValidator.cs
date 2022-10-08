using EmployeeManagementApi.Application.Query;
using FluentValidation;

namespace EmployeeManagementApi.Application.Validation
{
    public class GetEmployeeInsuranceQueryValidator : AbstractValidator<GetEmployeeInsuranceQuery>
    {
        public GetEmployeeInsuranceQueryValidator()
        {
            RuleFor(c => c.EmployeeId).NotEmpty().NotNull().WithMessage("Id (EmployeeId) is null");
        }
    }
}
