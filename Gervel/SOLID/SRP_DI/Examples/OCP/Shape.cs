using System;
using System.Linq;

namespace Examples.OCP {
	public interface IShape {
		double GetArea();
	}

	public abstract class Shape : IShape {
		public abstract double GetArea();
	}

	public class Rectangle : Shape {

		public Rectangle(double height, double width) {
			Width = width;
			Height = height;
		}

		public double Height { get; }
		public double Width { get; }

		public override double GetArea() {
			return Height * Width;
		}
	}

	public class Circle : Shape {
		public Circle(double radius) {
			Radius = radius;
		}
		public double Radius { get; }

		public override double GetArea() {
			return Radius * Radius * Math.PI;
		}
	}

	public class AreaCalculator {
		public static double TotalArea(params IShape[] shapes) {
			#region Option 1
			return shapes.Sum(c => c.GetArea());
			#endregion

			#region Option 2
			//double area = 0;
			//foreach (IShape shape in shapes) {
			//	area += shape.GetArea();
			//}

			//return area;
			#endregion
		}
	}
}
