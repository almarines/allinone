using Core;
using Core.Models;
using EmployeeManagementApi.Application.Commands;
using EmployeeManagementApi.Application.Query;
using EmployeeManagementApi.Application.Validation;
using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests.Application
{
    public class InsertEmployeeValidatorTests
    {
        //[Fact]
        [Theory]
        [InlineData("First", "Last", "email@y.com", 0)]
        [InlineData("First", "", "email@y.com", 1)]
        [InlineData("", "", "email@y.com", 2)]
        [InlineData("", "", "", 3)]
        public void InsertEmployee_Tests(string firstname, string lastname, string email, int expected)
        {
            // Arrange
            var validator = new InsertEmployeeCommandValidator();

            // Act
            var result = validator.Validate(new InsertEmployeCommand() { FirstName = firstname, LastName = lastname, Email = email });

            // Assert
            Assert.True(expected == result.Errors.Count);
        }
    }
}
