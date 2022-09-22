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
            var e = new Employee("First");

            // Act
            c.Add(e);

            // Assert
            Assert.NotEmpty(c.Name);
            Assert.NotNull(c["First"]);
            Assert.NotEmpty(c.Employees);
            Assert.Contains(e, c.Employees);
        }

        [Fact]
        public void AddEmployee_Exception_Test()
        {
            // Arrange
            var c = new Company("Test");
            var e = new Employee("");

            // Act
            Action action = () => c.Add(e);

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void RemoveCompany_Test()
        {
            // Arrange
            var c = new Company("Test");

            // Act
            c.Remove(c.Employees.First().Name);

            // Assert
            Assert.Empty(c.Employees);
        }

        [Fact]
        public void RemoveEmployee_Exception_Test()
        {
            // Arrange
            var c = new Company("Test");

            // Act
            Action action = () => c.Remove("Dummy");

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
