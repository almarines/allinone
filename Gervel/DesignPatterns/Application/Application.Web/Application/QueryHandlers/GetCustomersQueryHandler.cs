using Application.Web.Queries;
using Application.Web.Responses;
using Domain.Customer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Web.QueryHandlers {
	public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersResponse> {
		private readonly ICustomerRepository _customerRepository;

		public GetCustomersQueryHandler(ICustomerRepository customerRepository) {
			_customerRepository = customerRepository;
		}

		public async Task<GetCustomersResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken) {
			var customers = _customerRepository.GetAllCustomers();
			return await Task.FromResult(new GetCustomersResponse() { Customers = customers });
		}
	}
}
