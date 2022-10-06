using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.OCP
{
    public interface ICourse
    {
        public string CourseName { get; }
        IEnumerable<string> Modules { get; }      
    }

    public interface ICourseCost
    {
         long BasicCost { get; }

         long Tax { get; }

        abstract long TotalCost();
    }
    public interface ICourseCertification
    {
        IEnumerable<string> Certification { get; }
    }


    public abstract class Course : ICourse, ICourseCost
    {
        public Course(string name, long cost, long tax)
        {
            CourseName = name;
            BasicCost = cost;
            Tax = tax;
        }

        public string CourseName { get; }

        public long BasicCost { get; }

        public long Tax { get; }

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

    public class AdvanceDotNet : Course, ICourseCertification
    {
        public AdvanceDotNet(string name, long cost, long tax) : base(name, cost, tax)
        {

        }

        public override IEnumerable<string> Modules => new List<string> { "Garbage Collector" };

        public IEnumerable<string> Certification => new List<string> { "Garbage Collector Certification" };

        public override long TotalCost()
        {
            return BasicCost + Tax + 50;
        }
    }
}
