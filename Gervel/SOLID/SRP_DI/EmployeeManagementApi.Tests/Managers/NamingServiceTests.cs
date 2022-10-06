using EmployeeManagementApi.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementApi.Tests.Managers {

	public class NamingServiceTests {
		[Theory]
		[InlineData("", false)]
		[InlineData(null, false)]
		[InlineData("non-empty-string", true)]
		public void IsValid_String_Tests(string inputString, bool expected) {
			// Arrange
			var namingService = new NamingService();

			// Act
			var actual = namingService.IsValid(inputString);

			// Assert
			Assert.True(expected == actual);
		}

		[Theory]
		[InlineData(-1, false)]
		[InlineData(0, false)]
		[InlineData(1, true)]
		public void IsValid_Number_Tests(int inputNumber, bool expected) {
			// Arrange
			var namingService = new NamingService();

			// Act
			var actual = namingService.IsValid(inputNumber);

			// Assert
			Assert.True(expected == actual);
		}
	}
}
