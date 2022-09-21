using BasicModule;
using System;
using Xunit;

namespace XUnit_BasicModels_Tests {
  public class UnitTest1 {
    [Theory(DisplayName = "Add_Any_Test")]
    [InlineData(1, 2, 3)]
    [InlineData(0, 2, 2)]
    [InlineData(2, 0, 2)]
    public void Test1(int a, int b, int exkpectedResult) {
      // Arrange
      var mathinstanceObj = new MathInstance();
      // Act
      var result = mathinstanceObj.Add(a, b);
      // Assert
      Assert.Equal(exkpectedResult, result);
    }

    [Fact(DisplayName = "Add_Positive_Numbers")]
    public void Add_Positive_Numbers_Case() {
      // Arrange
      var mathinstanceObj = new MathInstance();
      // Act
      var result = mathinstanceObj.AddPositiveNumbers(1, 2);
      // Assert
      Assert.Equal(3, result);
    }

    [Theory(DisplayName = "Add_Negative_Numbers")]
    [InlineData(-1, 2, 2)]
    [InlineData(1, -2, 0)]
    public void Add_PositiveNumbers_Test_FailureCase(int a, int b, int exkpectedResult) {
      // Arrange
      var mathinstanceObj = new MathInstance();
      // Act
      Action result = () => mathinstanceObj.AddPositiveNumbers(a, b);
      // Assert
      Assert.Throws<InvalidOperationException>(result);
    }

    [Theory(DisplayName = "Add_Negative_Numbers_Out")]
    [InlineData(-1, 2, 2)]
    [InlineData(1, -2, 0)]
    public void Add_Negative_Numbers_Out(int a, int b, int exkpectedResult) {
      // Arrange
      var mathinstanceObj = new MathInstance();
      // Act
      Action result = () => mathinstanceObj.AddPositiveNumbers(a, b, out exkpectedResult);
      // Assert
      Assert.Throws<InvalidOperationException>(result);
    }

    [Theory(DisplayName = "MaxTest")]
    [InlineData(1, 1, 1)]
    [InlineData(1, 100, 100)]
    public void MaxTest(int a, int b, int exkpectedResult) {
      // Arrange
      var mathinstanceObj = new MathInstance();
      // Act
      var result = mathinstanceObj.Max(a, b);
      // Assert
      Assert.Equal(exkpectedResult, result);
    }
  }
}