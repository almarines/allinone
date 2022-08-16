using Application.Web.Queries;
using Application.Web.Responses;
using Domain.Customer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Web.QueryHandlers {
	public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerResponse> {
		private readonly ICustomerRepository _customerRepository;

		public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository) {
			_customerRepository = customerRepository;
		}

		public async Task<GetCustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken) {
			var customer = _customerRepository.GetCustomerById(request.CustomerId);
			return await Task.FromResult(new GetCustomerResponse() { Customer = customer });
		}
	}
}
