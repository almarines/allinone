using Core.Contracts;
using EmployeeManagementApi.Dto;
using EmployeeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Api.Tests
{
    public class EmployeeControllerTests
    {
        private static (EmployeeController, IEmployeeRepository) Setup()
        {
            var mockRepo = Substitute.For<IEmployeeRepository>();
            var mockLogger = Substitute.For<ILogger<EmployeeController>>();
            var mockMailService = Substitute.For<IMailService>();
            var controller = new EmployeeController(mockLogger, mockRepo, mockMailService);
            return (controller, mockRepo);
        }

        [Fact]
        public async Task GetAll_Test()
        {
            //Arrange
            var item = Setup();
            var mockRepo = item.Item2;
            var list = new List<Core.Models.Employee>() { new Core.Models.Employee() };
            mockRepo.GetAll().Returns(s =>
            {
                return list;
            });
            var controller = item.Item1;

            //Act
            var getAll = await controller.GetAll();
            var result = (getAll as OkObjectResult).Value as IEnumerable<Core.Models.Employee>;

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsType<List<Core.Models.Employee>>(result);
            await mockRepo.Received().GetAll();
        }

        [Fact]
        public async Task GetEmployeeById_Test()
        {
            //Arrange
            var item = Setup();
            var mockRepo = item.Item2;
            var list = new List<Core.Models.Employee>() { new Core.Models.Employee() };
            mockRepo.Get(Arg.Any<int>()).Returns(s =>
            {
                return list.First();
            });
            var controller = item.Item1;

            //Act
            var get = await controller.GetEmployeeById(1);
            var result = get as OkObjectResult;

            //Assert
            Assert.Same(list.First(), result.Value);
        }

        [Fact]
        public async Task InsertEmployee_Test()
        {
            //Arrange
            var item = Setup();
            var mockRepo = item.Item2;
            var list = new List<Core.Models.Employee>() { new Core.Models.Employee() 
            { FirstName = "test", LastName = "Last", Email = "test@email.com" } };
            mockRepo.InsertEmployee(Arg.Any<Core.Models.Employee>()).Returns(s =>
            {
                list.Add(s[0] as Core.Models.Employee);
                return 0;
            });
            var controller = item.Item1;

            //Act
            var insert = await controller.InsertEmployee(new EmployeeDto 
                { FirstName = "test", LastName = "Last", Email = "test@email.com" });
            var result = insert as OkObjectResult;

            // Assert
            Assert.Equal(list.First().Id, result.Value);
            Assert.NotNull(insert);
            await mockRepo.Received().InsertEmployee(Arg.Any<Core.Models.Employee>());
        }
    }
}
