using Domain.Customer.Repositories;
using LiteDB;
using System.Collections.Generic;

using Models = Domain.Customer.Models;

namespace Infrastructure.Customer.Repositories {
	public class CustomerRepository : ICustomerRepository {
		private readonly ILiteDBContext _context;

		public CustomerRepository(ILiteDBContext context) {
			_context = context;
		}

		public BsonValue InsertCustomer(Models.Customer customer) {
			var bsonValue = _context.InsertCustomer(customer);

			return bsonValue;
		}

		public IEnumerable<Models.Customer> GetAllCustomers() {
			var customers = _context.GetAllCustomers();

			return customers;
		}

		public Models.Customer GetCustomerById(int customerId) {
			var customer = _context.GetCustomerById(customerId);

			return customer;
		}

		public bool UpdateCustomer(Models.Customer customer) {
			var hasUpdated = _context.UpdateCustomer(customer);

			return hasUpdated;
		}

		public bool DeleteCustomerById(int customerId) {
			var hasDeleted = _context.DeleteCustomerById(customerId);

			return hasDeleted;
		}
	}
}
