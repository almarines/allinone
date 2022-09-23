using EmployeeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Xunit;

namespace Employee.Api.Tests.Controllers
{
    public class HomeControllerTests
    {

        [Fact]
        public void GetAll_test()
        {
            //Arrange
            var mockLogger = NSubstitute.Substitute.For<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger);

            //Act
            var getAll = controller.GetAll();
            var result = (getAll as OkObjectResult).Value as List<Core.Models.Employee>;

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
