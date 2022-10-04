using System;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using EmployeeManagementApi.Dto;
using NSubstitute;

namespace EmployeeManagementApi.Tests
{
    public class EmployeeControllerTests
    {
        private EmployeeDBContext employeeDBContext;
        private IOptions<DbConfig> dbOptions;

        [Theory]
        [InlineData("", "", "")]
        [InlineData("", "", "mr@kyocera.com")]
        [InlineData("", "Rica", "mr@kyocera.com")]
        [InlineData("", "Rica", "")]
        [InlineData("Myla", "", "mr@kyocera.com")]
        [InlineData("Myla", "Rica", "")]
        [InlineData("Myla", "Rica", "mr@kyocera.com")]
        public async void InsertEmployee_Tests_InvalidValidations(string firstName, string lastName, string email)
        {
            // Arrange
           // var namingService = Substitute.For<INamingService>();

            var c = new EmployeeController(null, null);

            EmployeeDto employee = new EmployeeDto {

                FirstName = "Myla",
                LastName = "Rica",
                Email = "mr@kii.com"
            };

            // Act
            var res = await c.InsertEmployee(employee);

            // Assert
            Assert.NotNull(res);
        }
    }
}
