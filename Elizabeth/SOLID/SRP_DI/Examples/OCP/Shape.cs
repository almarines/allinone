using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.OCP
{
    public interface IShape
    {
        double GetArea();
    }

    public abstract class Shape : IShape
    {
        public abstract double GetArea();
    }

    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; }
        public double Width { get; }

        public override double GetArea()
        {
            return Height * Width;
        }
    }

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }

    public class AreaCalculator
    {
        public static double TotalArea(params IShape[] arrObjects)
        {
            double area = 0;
            foreach (var obj in arrObjects)
            {
                area += obj.GetArea();
            }

            return area;
        }
    }
}
