using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementApi.Models {
	public abstract class Employee {
		/// <value>The id.</value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public int BasicPay { get; set; }

		public int HRA { get; set; }

		public int Bonus { get; set; }

		public string InsuranceType { get; set; }

		public bool IsFullTimeEmployee { get; set; }

		public abstract int GetSalary();

		public abstract string GetInsurance();
	}

	public class FullTimeEmployee : Employee {
		public override int GetSalary() {
			return BasicPay + HRA + Bonus;
		}
		public override string GetInsurance() {
			return "Max +";
		}
	}

	public class PartTimeEmployee : Employee {
		public override int GetSalary() {
			return BasicPay + HRA;
		}
		public override string GetInsurance() {
			return "Max";
		}

	}
}
