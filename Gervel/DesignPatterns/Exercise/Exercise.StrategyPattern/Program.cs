using System;
using System.Collections.Generic;

namespace Exercise.StrategyPattern {
	public class Program {
		static void Main(string[] args) {
            _ = args;

            var pythonTraining = new Training(new PythonTrainingStrategy());
            var goLangTraining = new Training(new GoLangTrainingStrategy());

            Console.WriteLine($"Python Trainig Cost: { pythonTraining.GetTrainignCost() }");
            Console.WriteLine($"Python Courses: [{ string.Join(", ", pythonTraining.GetCourses()) }]");
            Console.WriteLine($"\nGo Lang Trainig Cost: { goLangTraining.GetTrainignCost() }");
            Console.WriteLine($"Go Lang Courses: [{ string.Join(", ", goLangTraining.GetCourses()) }]");

            _ = Console.ReadKey();
        }
	}

	public class Training {
        private readonly ITrainingStrategy _trainingStrategy;

        public Training(ITrainingStrategy trainingStrategy) {
            _trainingStrategy = trainingStrategy;
        }

        public int GetTrainignCost() => _trainingStrategy.GetTrainignCost();
        public IEnumerable<string> GetCourses() => _trainingStrategy.GetCourses();
    }

    public interface ITrainingStrategy {
        public int GetTrainignCost();
        public IEnumerable<string> GetCourses();
    }

    public class PythonTrainingStrategy : ITrainingStrategy {
        public int GetTrainignCost() => 100;
        public IEnumerable<string> GetCourses() => new List<string> { "Basic Python", "Python SQL", "Dyngo" };
    }

    public class GoLangTrainingStrategy : ITrainingStrategy {
        public int GetTrainignCost() => 150;
        public IEnumerable<string> GetCourses() => new List<string> { "Basic Go" };
    }
}
