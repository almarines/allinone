using Domain.Customer.Repositories;
using Infrastructure.Customer.Options;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

using Models = Domain.Customer.Models;

namespace Infrastructure.Customer.Repositories {
	public class LiteDBContext : ILiteDBContext {
		private readonly LiteDatabase _context;
		private static ILiteCollection<Models.Customer> customerCollection;
		private static ILiteCollection<Models.Support> supportCollection;
		private string CustomerCollection = "Customers";
		private string SupportCollection = "Supports";

		public LiteDBContext(IOptions<DbConfig> configs) {
			try {
				if (_context == null) {
					_context = new LiteDatabase($"Filename={configs.Value.PathToDB};Connection=Direct");
					customerCollection = _context.GetCollection<Models.Customer>(CustomerCollection);
					supportCollection = _context.GetCollection<Models.Support>(SupportCollection);
				}
			} catch (Exception ex) {
				throw new Exception("Can find or create LiteDb database.", ex);
			}
		}

		public BsonValue InsertCustomer(Models.Customer customer) {
			customerCollection = _context.GetCollection<Models.Customer>(CustomerCollection);

			var bsonValue = customerCollection.Insert(customer);

			return bsonValue;
		}


		public IEnumerable<Models.Customer> GetAllCustomers() {
			var customers = customerCollection.FindAll();

			return customers;
		}

		public Models.Customer GetCustomerById(int customerId) {
			var bs = new BsonValue(customerId);

			var customer = customerCollection.FindById(bs);

			return customer;
		}

		public bool UpdateCustomer(Models.Customer customer) {
			var hasUpdated = customerCollection.Update(customer);

			return hasUpdated;
		}

		public bool DeleteCustomerById(int customerId) {
			var bs = new BsonValue(customerId);

			var hasDeleted = customerCollection.Delete(bs);

			return hasDeleted;
		}


		public Models.Support GetSupportByCustomerId(int customerId) {
			var bs = new BsonValue(customerId);

			var support = supportCollection.FindById(bs);

			return support;
		}

		public BsonValue InsertSupport(Models.Support support) {
			supportCollection = _context.GetCollection<Models.Support>(SupportCollection);

			var bsonValue = supportCollection.Insert(support);

			return bsonValue;
		}
	}
}