using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Examples.OCP {
	public class CourseCalculator {
		public static IEnumerable<Course> GetAll() {
			var list = new List<Course>();

			list.Add(new Python("Basics of Python", 1000, 20));
			list.Add(new AdvanceDotNet("Advance .Net", 2000, 40));
			return list;
		}

		public static double TotalCost(params Course[] courses) {
			#region Option 1
			return courses.Sum(c => c.TotalCost());
			#endregion

			#region Option 2
			//double cost = 0;

			//foreach (Course course in courses) {
			//	cost += course.TotalCost();
			//}

			//return cost;
			#endregion
		}

		public static IEnumerable<string> GetModules(Course course) {
			return course.Modules;
		}
	}
}
