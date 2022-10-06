using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Examples.OCP {
	public class CourseCalculator {
		public static IEnumerable<Course> GetAll() {
			var list = new List<Course>();
			list.Add(new Python() {
				CourseName = "Basics of Python",
				BasicCost = 1000,
				Tax = 20,
				Modules = new() {
					"Basic Fundamentals",
					"DataType in Python",
					"Loops for, while etc in Python"
				}
			});
			list.Add(new AdvanceDotNet() {
				CourseName = "Advance .Net",
				BasicCost = 2000,
				Tax = 40,
				Modules = new() {
					"Garbage Collector",
					"Memory Management",
					"Multi Threads"
				}
			});
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
