﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models {
	public abstract class Employee : IEmployee, ISalary, IBenefits {
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

		public abstract int GetSalary();

		public abstract string GetInsurance();
	}

	public interface IEmployee {
		int Id { get; set; }
		string Email { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
	}

	public interface ISalary {
		int BasicPay { get; set; }
		int Bonus { get; set; }
		int HRA { get; set; }
		int GetSalary();
	}

	public interface IBenefits {
		string InsuranceType { get; set; }
		string GetInsurance();
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