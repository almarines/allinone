using Core.Options;
using Dapper;
using DataBaseCore;
using DataBaseCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataBaseCore
{
    public interface IEmployeeDapperWrapper
    {
        Task<IEnumerable<T>> QueryAsync<T>(string q);

        Task<int> ExecuteAsync(string q);

        Task<int> ExecuteAsync(string query, object obj);
    }

    [ExcludeFromCodeCoverage]
    public class EmployeeDapperWrapper : IEmployeeDapperWrapper
    {
        private readonly EmployeeDBDapperContext employeeDBContext;

        public EmployeeDapperWrapper(EmployeeDBDapperContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using var connection = this.employeeDBContext.CreateConnection();
            return await connection.QueryAsync<T>(query);
        }

        public async Task<int> ExecuteAsync(string query)
        {
            using var connection = this.employeeDBContext.CreateConnection();
            return await connection.ExecuteAsync(query);
        }

        public async Task<int> ExecuteAsync(string query, object obj)
        {
            using var connection = this.employeeDBContext.CreateConnection();
            return await connection.ExecuteAsync(query, obj);
        }
    }
}

namespace Employee.Api.Tests.SqlServer.Dapper
    {

        public class EmployeeRepositoryTests
        {
            public EmployeeRepositoryTests()
            {

            }

            [Fact]
            public async void GetAll_Test()
            {
                // Arrange
                var mockWrapper = Setup();
                mockWrapper.QueryAsync<Core.Models.Employee>(Arg.Any<string>()).Returns(new List<Core.Models.Employee>() { new Core.Models.Employee() { FirstName = "test" } });
                var repo = new EmployeeRepository(mockWrapper);

                // Act
                var result = await repo.GetAll();

                // Assert
                Assert.Single(result);
            }

            private IEmployeeDapperWrapper Setup()
            {
                return Substitute.For<IEmployeeDapperWrapper>();
            }
        }

        //public class MockDbDapperContext : EmployeeDBDapperContext
        //{
        //    public MockDbDapperContext(IOptions<DbConfig> dbOptions) : base (dbOptions)
        //    {

        //    }

        //    public override IDbConnection CreateConnection()
        //    {
        //        return new MockDapperConnection();
        //    }
        //}

        //public class MockDapperConnection : IDbConnection
        //{
        //    public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //    public int ConnectionTimeout => throw new NotImplementedException();

        //    public string Database => throw new NotImplementedException();

        //    public ConnectionState State => throw new NotImplementedException();

        //    public IDbTransaction BeginTransaction()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IDbTransaction BeginTransaction(IsolationLevel il)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void ChangeDatabase(string databaseName)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Close()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IDbCommand CreateCommand()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Open()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public class MockDapperWrapper : IEmployeeDapperWrapper
        //{
        //    public Task<int> ExecuteAsync(string q)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> ExecuteAsync(string query, object obj)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<T>> QueryAsync<T>(string q)
        //    {
        //        if (q.Contains("Employee"))
        //        {
        //            var result = await Task.FromResult(new List<Core.Models.Employee>() { new Core.Models.Employee() { FirstName = "test" } });
        //            return result as IEnumerable<T>;
        //        }

        //        return null;
        //    }
        //}
    }
