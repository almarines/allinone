using Examples.OCP;
using System;

namespace Examples {
	class Program {
		static void Main(string[] args) {
			_ = args;

			Console.WriteLine("*** OCP Examples ****");

			Console.WriteLine("Enter Circle Radius : ");
			var radius = Console.ReadLine();
			var circle = new Circle(double.Parse(radius));

			Console.WriteLine("Enter Rectangle Height : ");
			var height = Console.ReadLine();
			Console.WriteLine("Enter Rectangle Width : ");
			var width = Console.ReadLine();
			var rectangle = new Rectangle(double.Parse(height), double.Parse(width));
			var totalArea = AreaCalculator.TotalArea(circle, rectangle);

			Console.WriteLine($"*** Circle Area : {circle.GetArea()}****");
			Console.WriteLine($"*** Rectangle Area : {rectangle.GetArea()}****");
			Console.WriteLine($"*** Total Area : {totalArea}****\n");

			double totalCost = 0;
			foreach (Course training in CourseCalculator.GetAll()) {
				totalCost += CourseCalculator.TotalCost(training);
				Console.WriteLine($"*** Modules : {string.Join("->", CourseCalculator.GetModules(training))} ****");
			}

			Console.WriteLine($"*** Total Training Cost : {totalCost} ****");
			Console.ReadLine();
		}
	}
}
