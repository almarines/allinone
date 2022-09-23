using EmployeeManagementApi.Controllers;
using EmployeeManagementApi.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async void GetEmployee_Tests()
        {
            // Arrange
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var list = new List<EmployeeManagementApi.Models.Employee>() { new EmployeeManagementApi.Models.Employee() };
            mockRepo.GetAll().Returns(s =>
            {
                return list;
            });

            var controller = new EmployeeController(mockRepo);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.Same(list, result);
        }
    }
}
