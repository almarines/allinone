using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Examples.OCP
{
    public interface IRectangle
    {
        double Height { get; }
        double Width { get; }     
    }
    public interface ICircle
    {    
        double Radius { get; }
    }


    public abstract class Shape : IRectangle, ICircle
    {
        public Shape(double height, double width, double radius)
        {
            Height = height;
            Width = width;
            Radius = radius;            
        }

        public double Height { get; }
        public double Width { get;  }
        public double Radius { get;  }

        //public abstract string ObjectShape();

        public abstract long TotalArea();
       
    }

    public class Rectangle : Shape
    {
        public Rectangle(double height, double width, double radius) : base(height, width, radius)
        {

        }

        public override long TotalArea()
        {
            Shape shape;
            long calc = (long)(Height * Width);
            return calc;
        }
       
    }
    public class Circle : Shape
    {
        public Circle(double height, double width, double radius) : base(height, width, radius)
        {

        }

        public override long TotalArea()
        {          
            return (long)(Radius * Math.PI);
        }

    }

    //public class Circle
    //{
    //    public double Radius { get; set; }
    //}


    //public class AreaCalculator
    //{
    //    public static double TotalArea(params object[] arrObjects)
    //    {
    //        double area = 0;
    //        Circle objCircle;
    //        foreach (var obj in arrObjects)
    //        {
    //            if (obj is Rectangle objRectangle)
    //            {
    //                area += objRectangle.Height * objRectangle.Width;
    //            }
    //            else
    //            {
    //                objCircle = (Circle)obj;
    //                area += objCircle.Radius * objCircle.Radius * Math.PI;
    //            }
    //        }

    //        return area;
    //    }

}
