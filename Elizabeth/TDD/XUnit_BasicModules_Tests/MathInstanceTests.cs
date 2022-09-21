using BasicModule;
using System;
using Xunit;

namespace XUnit_BasicModules_Tests
{
    public class MathInstanceTests
    {
        [Fact(DisplayName = "Add_Simple_Test")]
        public void Add_Test()
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            var result = mathInstanceObj.Add(1, 2);

            //Assert
            Assert.Equal(3, result);
        }

        //[Fact(DisplayName = "Add_Positive_Numbers")]
        [Theory(DisplayName = "Add_Positive_Numbers")]
        [InlineData(1,2,3)]
        public void AddPositiveNumbers_Test_PositiveCase(int a, int b, int expected)
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            var result = mathInstanceObj.AddPositiveNumbers(a, b);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "Add_Negative_Numbers")]
        public void AddPositiveNumbers_Test_FailureCase()
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            Action result = () => mathInstanceObj.AddPositiveNumbers(-1, 2);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact(DisplayName = "Add_Negative_Numbers_Out_Failure")]
        public void AddPositiveNumbers_Out_result_Test_NegativeCase()
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            Action result = () => mathInstanceObj.AddPositiveNumbers(-1, 2, out int addResult);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

        [Fact(DisplayName = "Add_Negative_Numbers_Out_Result")]
        public void AddPositiveNumbers_Out_result_Test_PositiveCase()
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            mathInstanceObj.AddPositiveNumbers(1, 2, out int result);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact(DisplayName = "Max_Test")]
        public void Max_Test()
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            var result = mathInstanceObj.Max(1, 2);

            //Assert
            Assert.Equal(2, result);
        }
    }
}
