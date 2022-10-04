using Amazon.Runtime.Internal.Util;
using Core.Contracts;
using DataBaseCore.DBContext;
using EmployeeManagementApi.Dto;
using EmployeeWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Employee.Api.Test
{
    public class EmployeeControllerTest
    {
        private EmployeeDBContext dbContext;

        public EmployeeControllerTest()
        {
            var option = new DbContextOptionsBuilder<EmployeeDBContext>()
                                .UseInMemoryDatabase("Test").Options;
            this.dbContext = new EmployeeDBContext(option);

        }

        [Fact]
        public async Task GettAll_TestFailAsync()
        {
          
            //Arrange
            var itemSetup = Setup();
            var controller = itemSetup.Item1;
            var repo = itemSetup.Item2;
            repo.GetAll().Returns(new List<Core.Models.Employee>() { new Core.Models.Employee() });

            //Act

            var list = await controller.GetAll();
            var result = list as OkObjectResult;
         // var result = (getAll as OkObjectResult).Value as IEnumerable<EmployeeDto>;

            //Assert
            

            Assert.NotNull(result);
            Assert.IsType<List<Core.Models.Employee>>(result.Value);
            await repo.Received().GetAll();


        }


        private static (EmployeeController, IEmployeeRepository mockEmployeeRepository, IMailService mockMailService) Setup()
        {
            var mockLogger = NSubstitute.Substitute.For<ILogger<EmployeeController>>();
            var mockEmployeeRepository = NSubstitute.Substitute.For<IEmployeeRepository>();
            var mockMailService = NSubstitute.Substitute.For<IMailService>();
            var controller = new EmployeeController(mockLogger, mockEmployeeRepository, mockMailService);

            return (controller, mockEmployeeRepository, mockMailService);
        }
    }
}