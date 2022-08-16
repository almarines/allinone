using Domain.Customer.Models;
using System.Collections.Generic;

namespace Application.Web.Responses {
	public class GetCustomersResponse {
		public IEnumerable<Customer> Customers { get; set; }
	}
}
