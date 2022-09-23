using DataBaseCore;
using DataBaseCore.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests.SqlServer
{
    public class EmployeeRepositoryTests
    {
        private readonly  EmployeeDBContext dbConext;

        public EmployeeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EmployeeDBContext>()
               .UseInMemoryDatabase("test")
               .Options;
            this.dbConext = new EmployeeDBContext(options);
        }

        [Fact]
        public async void GetAll_Test()
        {
            // Arrange
            Setup();
            var repo = new EmployeeRepository(this.dbConext);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.Single(result);
        }

        private void Setup()
        {
            this.dbConext.Add(new Core.Models.Employee() { FirstName = "test" });
            this.dbConext.SaveChanges();
        }
    }
}
