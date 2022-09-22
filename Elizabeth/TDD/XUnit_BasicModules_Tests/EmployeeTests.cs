using BasicModule.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnit_BasicModules_Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_Test()
        {
            // Arrange
            var e = new Employee("Test");

            // Act
            // Assert
            Assert.Equal("Test", e.Name);
            Assert.IsType<Guid>(e.Id);
            Assert.NotNull(e.Id.ToString());
        }
    }
}
