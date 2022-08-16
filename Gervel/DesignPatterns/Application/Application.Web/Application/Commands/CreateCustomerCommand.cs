using Application.Web.Responses;
using MediatR;

namespace Application.Web.Commands {
	public class CreateCustomerCommand : IRequest<CreateCustomerResponse> {
		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string City { get; set; }

		public string CompanyName { get; set; }
	}
}
