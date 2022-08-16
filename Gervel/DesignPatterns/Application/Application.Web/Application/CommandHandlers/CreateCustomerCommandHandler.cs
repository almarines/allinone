using Application.Web.Commands;
using Application.Web.Responses;
using Domain.Customer.Models;
using Domain.Customer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Web.CommandHandlers {
	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse> {
		private readonly ICustomerRepository _customerRepository;

		public CreateCustomerCommandHandler(ICustomerRepository customerRepository) {
			_customerRepository = customerRepository;
		}

		public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken) {
			var result = _customerRepository.InsertCustomer(new Customer() { Id = request.Id, Name = request.Name, City = request.City, CompanyName = request.CompanyName, PhoneNumber = request.PhoneNumber });
			return await Task.FromResult(new CreateCustomerResponse { Id = result.AsInt32 });
		}
	}
}
