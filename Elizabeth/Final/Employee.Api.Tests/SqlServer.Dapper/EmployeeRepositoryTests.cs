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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests.SqlServer.Dapper
{
    public class EmployeeRepositoryTests
    {
        public EmployeeRepositoryTests()
        {

        }

        [Fact]
        public async Task GetAll_Test()
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

        [Fact]
        public async Task Insert_Test()
        {
            // Arrange
            var mockWrapper = Setup();
            var list = new List<Core.Models.Employee>() { new Core.Models.Employee() { FirstName = "test" } };
            mockWrapper.ExecuteAsync(Arg.Any<string>()).Returns(s =>
            {
                list.Add(s[0] as Core.Models.Employee);
                return 1;
            });
            var repo = new EmployeeRepository(mockWrapper);

            // Act
            var result = await repo.InsertEmployee(list.First());

            // Assert
            Assert.Equal(result, list.First().Id);
        }

        [Fact]
        public async Task GetById_Test()
        {
            // Arrange
            var mockWrapper = Setup();
            var employee = new Core.Models.Employee() { FirstName = "test" };
            mockWrapper.QueryAsync<Core.Models.Employee>(Arg.Any<string>()).Returns(new List<Core.Models.Employee>() { employee });
            var repo = new EmployeeRepository(mockWrapper);

            // Act
            var result = await repo.Get(1);

            // Assert
            Assert.Equal(result, employee);
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
