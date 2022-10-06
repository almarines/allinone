using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.OCP
{
    public abstract class Shape
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
        private double Height { get; set; }
        private double Width { get; set; }

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
        private double Radius { get; set; }

        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }

    public class AreaCalculator
    {
        public static double TotalArea(params Shape[] arrObjects)
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
