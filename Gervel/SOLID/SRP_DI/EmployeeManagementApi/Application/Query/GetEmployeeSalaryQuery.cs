using Core.Models;
using MediatR;
using System;

namespace EmployeeManagementApi.Application.Query
{
    public class GetEmployeeSalaryQuery : IRequest<int>
    {
		public int EmployeeId { get; set; }
	}
}
