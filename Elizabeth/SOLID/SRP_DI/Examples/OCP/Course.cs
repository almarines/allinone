using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Examples.OCP
{
    public abstract class Course
    {
        public Course(string courseName, long basicCost, long tax)
        {
            CourseName = courseName;
            BasicCost = basicCost;
            Tax = tax;
        }

        protected internal string CourseName { get; }

        protected internal long BasicCost { get; }

        protected internal long Tax { get; }

        public abstract double TotalCost();
        public abstract IEnumerable<string> Modules { get; }
    }


    public class Python : Course
    {
        public Python(string courseName, long basicCost, long tax) : base(courseName, basicCost, tax)
        {

        }
        public override IEnumerable<string> Modules => new List<string>() { "Basic Fundamentals", "DataType in Python", "Loops for, while etc in Python" };

        public override double TotalCost()
        {
            return (BasicCost * Tax) + 100;
        }
    }

    public class AdvanceDotNet : Course
    {
        public AdvanceDotNet(string courseName, long basicCost, long tax) : base(courseName, basicCost, tax)
        {

        }

        public override IEnumerable<string> Modules => new List<string>() { "Garbage Collector", "Memory Management", "Multi Threads" };

        public override double TotalCost()
        {
            return (BasicCost * Tax) + 50;
        }
    }
}
