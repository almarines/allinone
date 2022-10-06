using System;
using System.Linq;

namespace Examples.OCP {
	public abstract class Shape {
		public abstract double GetArea();
	}

	public class Rectangle : Shape {

		public double Height { get; set; }
		public double Width { get; set; }

		public override double GetArea() {
			return Height * Width;
		}
	}

	public class Circle : Shape {
		public double Radius { get; set; }

		public override double GetArea() {
			return Radius * Radius * Math.PI;
		}
	}

	public class AreaCalculator {
		public static double TotalArea(params Shape[] shapes) {
			#region Option 1
			return shapes.Sum(c => c.GetArea());
			#endregion

			#region Option 2
			//double area = 0;
			//foreach (Shape shape in shapes) {
			//	area += shape.GetArea();
			//}

			//return area;
			#endregion
		}
	}
}
