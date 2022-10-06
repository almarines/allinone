using System.Collections.Generic;

namespace Examples.OCP {
	public abstract class Course {

		public Course(string name, long cost, long tax) {
			CourseName = name;
			BasicCost = cost;
			Tax = tax;
		}

		protected internal string CourseName { get; }
		protected internal long BasicCost { get; }
		protected internal long Tax { get; }

		public abstract IEnumerable<string> Modules { get; }

		public abstract double TotalCost();
	}

	public class Python : Course {

		public Python(string name, long cost, long tax) : base(name, cost, tax) {
		}

		public override IEnumerable<string> Modules => new List<string>()
		{
			"Basic Fundamentals",
			"DataType in Python",
			"Loops for, while etc in Python"
		};

		public override double TotalCost() {
			return (BasicCost * Tax) + 100;
		}
	}

	public class AdvanceDotNet : Course {

		public AdvanceDotNet(string name, long cost, long tax) : base(name, cost, tax) {
		}

		public override IEnumerable<string> Modules => new List<string>()
		{
			"Garbage Collector",
			"Memory Management",
			"Multi Threads"
		};

		public override double TotalCost() {
			return (BasicCost * Tax) + 50;
		}
	}
}
