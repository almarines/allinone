using BasicModule.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnit_BasicModules_Tests
{
    public class CompanyTests
    {
        [Fact]
        public void Company_Test()
        {
            // Arrange
            var c = new Company("Test");

            // Act
            // Assert
            Assert.Single(c.Employees);
        }

        [Fact]
        public void AddEmployee_Test()
        {
            // Arrange
            var c = new Company("Test");
            var e = new Employee("First", 1);

            // Act
            c.Add(c);

            // Assert
            Assert.NotEmpty(c.Name);
            //Assert.NotNull(c["First"]);
            Assert.NotEmpty(c.Employees);
            Assert.Contains(e, c.Employees);
        }
    }
}
