using EmployeeManagementApi.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests.Managers
{
    public class NamingServiceTests
    {
        [Theory]
        [InlineData("x", true)]
        public void IsValidTests(string input, bool result)
        {
            //Arrange
            var namingService = new NamingService();

            //Act
            var actualResult = namingService.IsValid(input);

            //Assert
            Assert.Equal(result, actualResult);
        }
    }
}
