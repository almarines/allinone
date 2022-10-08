using MediatR;
using System;

namespace EmployeeManagementApi.Application.Query {
	public class GetEmployeeInsuranceQuery : IRequest<string> {
		public int EmployeeId { get; set; }
	}
}
