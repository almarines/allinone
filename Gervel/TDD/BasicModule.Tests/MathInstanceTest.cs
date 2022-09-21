namespace BasicModule.Tests {
	public class MathInstanceTest {
		[Fact]
		public void Add_Test() {
			var mi = new MathInstance();

			var actual = mi.Add(1, 2);
			var expected = 3;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Add_Positive_NormalCase() {
			var mi = new MathInstance();

			var actual = mi.AddPositiveNumbers(1, 2);
			var expected = 3;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(-1, 2)]
		[InlineData(1, -2)]
		[InlineData(-1, -2)]
		public void Add_Positive_InvalidCase(int a, int b) {
			var mi = new MathInstance();

			Action actual = () => mi.AddPositiveNumbers(a, b);

			Assert.Throws<InvalidOperationException>(actual);
		}

		[Theory]
		[InlineData(1, 2, 2)]
		[InlineData(2, 1, 2)]
		public void Max_NormalCase(int a, int  b, int expected) {
			var mi = new MathInstance();

			var actual = mi.Max(a, b);

			Assert.Equal(expected, actual);
		}
	}
}