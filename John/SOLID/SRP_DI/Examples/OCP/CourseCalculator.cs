using System.Collections.Generic;

namespace Examples.OCP
{
    public class CourseCalculator
    {
        public static IEnumerable<Course> GetAll()
        {
            var list = new List<Course>();
            list.Add(new Python("Basics of Python", 1000, 20 ));
            list.Add(new AdvanceDotNet("Advance .Net", 2000, 40 ));
            return list;
        }

        public static double TotalCost(params Course[] arrObjects)
        {
            double cost = 0;
            foreach (var obj in arrObjects)
            {
                cost += obj.GetTotalCost();
            }

            return cost;
        }

        public static IEnumerable<string> GetModules(Course obj)
        {
            return obj.GetModules;
        }
    }
}
