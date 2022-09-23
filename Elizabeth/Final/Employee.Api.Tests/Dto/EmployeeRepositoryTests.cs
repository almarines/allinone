using Core.Contracts;
using DataBaseCore;
using DataBaseCore.DBContext;
using EmployeeManagementApi.Dto;
using EmployeeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests
{
    public class EmployeeRepositoryTests
    {
        private readonly EmployeeDBContext dBContext;

        public EmployeeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EmployeeDBContext>()
                .UseInMemoryDatabase("test")
                .Options;
            dBContext = new EmployeeDBContext(options);
        }

        private void Setup()
        {
            dBContext.Add(new Core.Models.Employee() { FirstName = "test"});
            dBContext.SaveChanges();

        }

        [Fact]
        public async Task GetAll_Test()
        {
            //Arrange
            Setup();
            var repo = new EmployeeRepository(dBContext);

            //Act
            var result = await repo.GetAll();

            //Assert
            Assert.Single(result);
        }

    }
}
