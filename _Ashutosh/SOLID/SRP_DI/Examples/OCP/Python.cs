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

        protected long BasicCost { get;}

        protected long Tax { get; }

        public abstract long TotalCost();

        public abstract IEnumerable<string> Modules { get; }
    }

    public class Python : Course
    {
        public Python(string name, long cost, long tax): base(name, cost, tax)
        {

        }

        public override IEnumerable<string> Modules => new List<string> { "Basic Fundamentals" };

        public override long TotalCost()
        {
           return BasicCost + Tax + 100;
        }
    }

    public class AdvanceDotNet : Course
    {
        public AdvanceDotNet(string name, long cost, long tax) : base(name, cost, tax)
        {

        }

        public override IEnumerable<string> Modules => new List<string> { "Garbage Collector" };

        public override long TotalCost()
        {
            return BasicCost + Tax + 50;
        }
    }
}
