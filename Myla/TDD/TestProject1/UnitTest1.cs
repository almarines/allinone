using BasicModule;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact(DisplayName ="Add_Negative_Numbers_Out_Result")]
        public void Add_Negative_Numbers_Out_Result()
        {
            var mathInstance = new MathInstance();

            Action result = () => mathInstance.AddPositiveNumbers(-1, -2, out int result);

            Assert.Throws<InvalidOperationException>(result);
        }


        [Fact(DisplayName = "Add_Positive_Numbers_Out_Result")]
        public void Add_Positive_Numbers_Out_Result()
        {
            var mathInstance = new MathInstance();

            mathInstance.AddPositiveNumbers(1, 2, out int result);

            Assert.Equal(3, result);
        }

        [Fact]
        public void MaxTest()
        {
            var mathInstance = new MathInstance();

            mathInstance.Max(1, 2, out int result);


            Assert.Equal(2, result);
            
        }
    }
}
