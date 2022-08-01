using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConcepts.Model.Models
{
    internal class Training
    {
        private static string MyPro;

        public event EventHandler OnTrainingCreated;

        public Training(string n, string c, int cost)
        {
            Name = n;
            CourseType = c;
            Cost = cost;
        }

        public string Name { get; set; }

        public string CourseType { get; set; }

        public int Cost { get; set; }

        public string GetFullDetails()
        {
            return Name + CourseType + Cost;
        }
    }
}
