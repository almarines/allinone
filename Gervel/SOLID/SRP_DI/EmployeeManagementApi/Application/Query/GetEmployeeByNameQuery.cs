using Core.Models;
using MediatR;
using System;

namespace EmployeeManagementApi.Application.Query
{
    public class GetEmployeeByNameQuery : IRequest<Employee>
    {
		public string FirstName { get; set; }
	}
}
