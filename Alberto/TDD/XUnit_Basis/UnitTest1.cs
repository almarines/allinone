using BasicModule;

namespace XUnit_Basis
{
    public class UnitTest1
    {


        [Theory(DisplayName = "Add_Positive_Numbers")]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 6)]

        public void AddPositiveNumbersTest(int a, int b, int expected)
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            var result = mathInstanceObj.AddPositiveNumbers(a, b);

            //Assert
            Assert.Equal(expected, result);
        }


        [Fact(DisplayName = "Add_Negative_Numbers")]
        public void AddPositiveNumbersFailCase()
        {
            //Arrange
            var mathInstanceObj = new MathInstance();

            //Act
            Action result = () => mathInstanceObj.AddPositiveNumbers(-1, 2);

            //Assert
            Assert.Throws<InvalidOperationException>(result);
        }

               

        [Fact(DisplayName = "Add")]
        public void Test_MaxFact()
        {
            //Arrange
            var nathObj = new MathInstance();

            // Act
            var result = nathObj.Max(1, 2);

            //Assert
            Assert.Equal(2, result);

        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 1, 4)]
        public void Test_Max_Theory(int a, int b, int inspected)
        {
            //Arrange
            var nathObj = new MathInstance();

            // Act
            var result = nathObj.Max(a, b);

            //Assert
            Assert.Equal(inspected, result);

        }

    }
}