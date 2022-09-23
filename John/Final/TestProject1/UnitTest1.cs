using Core.Models;
using DataBaseCore;
using DataBaseCore.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var options = new DbContextOptionsBuilder<EmployeeDBContext>()
                  .UseInMemoryDatabase("test")
                  .Options;

            await using var context = new EmployeeDBContext(options);
            context.Employees.Add(new Employee());
            await context.SaveChangesAsync();

            var repo = new EmployeeRepository(context);
            var em = await repo.GetAll();
        }
    }
}
