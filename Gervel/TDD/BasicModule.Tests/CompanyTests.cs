using BasicModule.BasicClasses;
using System.Diagnostics.CodeAnalysis;

namespace BasicModule.Tests {

    [ExcludeFromCodeCoverage]
	public class CompanyTests {
        [Fact]
        public void Company_Test() {
            var c = new Company("Test");

            Assert.Single(c.Employees);
        }

        [Fact]
        public void AddEmployee_Test() {
            var c = new Company("Company");
            var e = new Employee("First");

            c.Add(e);

            Assert.NotEmpty(c.Name);
            Assert.NotNull(c["First"]);
            Assert.NotEmpty(c.Employees);
            Assert.Contains(e, c.Employees);
        }

        [Fact]
        public void AddEmployee_HandleInvalid() {
            var c = new Company("Company");

            var add = () => c.Add(new Employee(""));

            Assert.Throws<InvalidOperationException>(add);
        }

        [Fact]
        public void RemoveEmployee_NormalCase() {
			var c = new Company("Company");

            c.Remove("First Emp");

            Assert.Null(c["First Emp"]);
            Assert.Empty(c.Employees);
		}

		[Fact]
		public void RemoveEmployee_HandleInvalid() {
			var c = new Company("Company");

			var remove = () => c.Remove("Employee 3");

			Assert.Throws<InvalidOperationException>(remove);
		}
	}
}
