using Core;
using EmployeeManagementApi.Application.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Application.QueryHandlers {
    public class GetEmployeeInsuranceQueryHandler : IRequestHandler<GetEmployeeInsuranceQuery, string> {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeInsuranceQueryHandler(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        public async Task<string> Handle(GetEmployeeInsuranceQuery request, CancellationToken cancellationToken) {
            _ = cancellationToken;

            return await _employeeRepository.GetInsurance(request.EmployeeId);

		}
    }
}
