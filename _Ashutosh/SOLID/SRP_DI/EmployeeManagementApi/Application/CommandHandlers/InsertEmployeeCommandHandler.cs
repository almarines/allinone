using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Models;
using EmployeeManagementApi.Application.Commands;
using MediatR;

namespace EmployeeManagementApi.Application.CommandHandlers
{
    public class InsertEmployeeCommandHandler : IRequestHandler<InsertEmployeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public InsertEmployeeCommandHandler(IEmployeeRepository employeeRepo)
        {
            _employeeRepository = employeeRepo;
        }
        public async Task<int> Handle(InsertEmployeCommand request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.InsertEmployee(new FullTimeEmployee() { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email });
        }
    }
}
