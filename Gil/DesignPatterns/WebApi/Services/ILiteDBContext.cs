using LiteDB;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Services
{
    public interface ILiteDBContext
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        BsonValue InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomerById(int customerId);
    }
}