using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.OCP
{

    public abstract class Course
    {
        public Course(string name, long cost, long tax)
        {
            CourseName = name;
            BasicCost = cost;
            Tax = tax;
        }

        protected internal string CourseName { get; }
        protected long BasicCost { get; }
        protected long Tax { get; }

        public abstract long GetTotalCost();
        public abstract IEnumerable<string> GetModules { get; }
    }


    public class Python : Course
    {
        public Python(string name, long cost, long tax) : base(name, cost, tax)
        {

        }

        public override long GetTotalCost()
        {
            return (BasicCost * Tax) + 100;
        }

        public override IEnumerable<string> GetModules => new List<string>() {
                "Basic Fundamentals",
                "DataType in Python",
                "Loops for, while etc in Python"
            };


    }

    public class AdvanceDotNet : Course
    {
        public AdvanceDotNet(string name, long cost, long tax) : base(name, cost, tax)
        {

        }
        public override long GetTotalCost()
        {
            return (BasicCost * Tax) + 50;
        }

        public override IEnumerable<string> GetModules => new List<string>() {
                "Garbage Collector",
                "Memory Managementn",
                "Multi Threads"
            };
    }
}
