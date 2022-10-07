using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.OCP
{
    public abstract class Course
    {
        public string CourseName { get; set; }
        public long BasicCost { get; set; }
        public long Tax { get; set; }
        public List<string> Modules { get; set; }

        public abstract double TotalCost();
    }

    public class Python : Course
    {
        public override double TotalCost()
        {
            return (BasicCost * Tax) + 100;
        }
    }

    public class AdvanceDotNet : Course
    {

        public override double TotalCost()
        {
            return (BasicCost * Tax) + 50;
        }
    }
}
