using LiteDB;
using System.Collections.Generic;

namespace Domain.Customer.Repositories {
	public interface ICustomerRepository {
		IEnumerable<Models.Customer> GetAllCustomers();
		Models.Customer GetCustomerById(int customerId);
		BsonValue InsertCustomer(Models.Customer customer);
		bool UpdateCustomer(Models.Customer customer);
		bool DeleteCustomerById(int customerId);
	}
}
