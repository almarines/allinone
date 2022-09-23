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
        private readonly EmployeeDBContext employeeDBContext;

        public EmployeeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EmployeeDBContext>()
                .UseInMemoryDatabase("test")
                .Options;
            this.employeeDBContext = new EmployeeDBContext(options);
        }

        [Fact]
        public void GetAll_test()
        {
            //Arrange
            Setup();
            var repo = new EmployeeRepository(this.employeeDBContext);

            //Act
            var result = repo.GetAll();

            //Assert
            Assert.Single((System.Collections.IEnumerable)result);
        }

        public void Setup()
        {
            this.employeeDBContext.Add(new Core.Models.Employee() { FirstName = "John" });
            this.employeeDBContext.SaveChanges();

        }
    }
}
