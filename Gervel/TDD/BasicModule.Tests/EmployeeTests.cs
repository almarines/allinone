﻿using BasicModule.BasicClasses;
using System.Diagnostics.CodeAnalysis;

namespace BasicModule.Tests {

	[ExcludeFromCodeCoverage]
	public class EmployeeTests {

		[Fact]
		public void EmployeeInstance_NormalCase() {
			var e = new Employee("Employee 1");

			Assert.NotEmpty(e.Name);
			Assert.NotNull(e.Name);
			Assert.NotNull(e.Id); // ?
		}

		[Fact]
		public void FullTimeEmployee_NormalCase() {
			var e = new FullTimeEmp("Fulltime Employee 1");

			Assert.NotEmpty(e.Name);
			Assert.NotNull(e.Name);
			Assert.NotNull(e.Id); //?
			Assert.IsAssignableFrom<Employee>(e);
		}

		[Fact]
		public void PartTimeEmployee_NormalCase() {
			var e = new PartTimeEmp("Part-time Employee 1");

			Assert.NotEmpty(e.Name);
			Assert.NotNull(e.Name);
			Assert.NotNull(e.Id); // ?
			Assert.IsAssignableFrom<Employee>(e);
		}
	}
}
