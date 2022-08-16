using Application.Web.Responses;
using MediatR;

namespace Application.Web.Queries {
	public class GetCustomerByIdQuery : IRequest<GetCustomerResponse> {
		public int CustomerId { get; set; }
	}
}
