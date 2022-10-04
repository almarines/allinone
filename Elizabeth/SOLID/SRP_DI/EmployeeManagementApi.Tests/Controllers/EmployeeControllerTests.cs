using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using EmployeeManagementApi.Managers;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;
using static System.Collections.Specialized.BitVector32;

namespace EmployeeManagementApi.Tests
{
    public class EmployeeControllerTests
    {
        //[Fact]
        [Theory]
        [InlineData("", "", "")]
        [InlineData("First", "Last", "")]
        [InlineData("First", "", "")]
        [InlineData("", "Last", "")]
        [InlineData("", "Last", "email")]
        [InlineData("First", "Last", "email")]
        [InlineData("First", "Last", "email@y.com")]
        public async Task InsertEmployee_Tests(string firstname, string lastname, string email)
        {
            // Arrange
            var employeeDto = new EmployeeDto() { FirstName = firstname, LastName = lastname, Email = email };
            var mockNamingService = Substitute.For<NamingService>();
            //var mockDbContext = Substitute.For<EmployeeDBContext>();
            //var mockDbOptions = Substitute.For<IOptions<DbConfig>>();
            var dbPath = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\elizabeths\\source\\repos\\AdvanceNetConcepts\\Elizabeth\\SOLID\\SRP_DI\\EmployeeManagementApi\\oldemployee.mdf;Integrated Security=True;Connect Timeout=30";
            var controller = new EmployeeController(dbPath, mockNamingService/*mockDbContext, mockDbOptions*/);

            // Act
            //var result = await controller.InsertEmployee(employeeDto);
            //var r = result as OkObjectResult;


            //var stmpMockObj = Substitute.For<SMTPMailService>();
            //await stmpMockObj.SendMail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
            //Container.AddSingelten<SMTPMailService>(stmpMockObj);
            Func<Task> action = async () => await controller.InsertEmployee(employeeDto);

            // Assert
            //Assert.Equal(true, r.Value);

            await Assert.ThrowsAsync<InvalidOperationException>(action);
        }
    }
}
