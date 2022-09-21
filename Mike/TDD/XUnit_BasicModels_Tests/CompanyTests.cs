using BasicModule.BasicClasses;
using Xunit;

namespace XUnit_BasicModels_Tests {
  public class CompanyTests {
    [Fact]
    public void AddEmployee_Test() {
      // Arrange
      var c = new Company("Test");
      var e = new Employee("First");
      // Act
      c.Add(e);
      // Assert
      Assert.NotEmpty(c.Name);
      Assert.NotEmpty(c.Employees);
      Assert.Contains(e, c.Employees);
    }
  }
}
