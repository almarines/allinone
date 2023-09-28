using Core;
using Core.Models;
using EmployeeManagementApi.Application.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Application.QueryHandlers
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetById(request.Id);
        }
    }
}
