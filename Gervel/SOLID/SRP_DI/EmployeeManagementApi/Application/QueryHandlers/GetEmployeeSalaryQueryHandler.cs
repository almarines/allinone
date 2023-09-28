using Core;
using Core.Models;
using EmployeeManagementApi.Application.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Application.QueryHandlers {
    public class GetEmployeeSalaryQueryHandler : IRequestHandler<GetEmployeeSalaryQuery, int> {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeSalaryQueryHandler(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(GetEmployeeSalaryQuery request, CancellationToken cancellationToken) {
            _ = cancellationToken;

            return await _employeeRepository.GetSalary(request.EmployeeId);

		}
    }
}
