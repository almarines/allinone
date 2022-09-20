using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WebApi.Models;
using WebApi.Options;

namespace WebApi.Services
{
    public class LiteDBContext : ILiteDBContext
    {
        private readonly LiteDatabase _context;
        private static ILiteCollection<Customer> collection;
        private string nameOfCollection = "Customers";

        public LiteDBContext(IOptions<DbConfig> configs)
        {
            try
            {
                if (_context == null)
                {
                    _context = new LiteDatabase($"Filename={configs.Value.PathToDB};Connection=Direct");
                    collection = _context.GetCollection<Customer>(nameOfCollection);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public BsonValue InsertCustomer(Customer customer)
        {
            collection = _context.GetCollection<Customer>(nameOfCollection);

            var bsonValue = collection.Insert(customer);

            return bsonValue;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = collection.FindAll();

            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var bs = new BsonValue(customerId);

            var customer = collection.FindById(bs);

            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var hasUpdated = collection.Update(customer);

            return hasUpdated;
        }

        public bool DeleteCustomerById(int customerId)
        {
            var bs = new BsonValue(customerId);

            var hasDeleted = collection.Delete(bs);

            return hasDeleted;
        }
    }
}