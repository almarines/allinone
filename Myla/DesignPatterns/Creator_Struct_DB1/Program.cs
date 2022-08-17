using System;
using System.Collections.Generic;

namespace Creator_Struct_DP1
{
    class Program
    {
        static void Main(string[] args)
        {
            var python = new Training(new PythonTrainingStrategy());
            var go = new Training(new GoLangTrainingStrategy());

            Console.WriteLine(python.TrainingCost());
            Console.WriteLine(python.Courses());
            Console.WriteLine(go.TrainingCost());
            Console.WriteLine(go.Courses());

            Console.ReadKey();
        }
    }

    public class Training
    {
        private readonly ITrainingStrategy _trainingStrategy;

        public Training(ITrainingStrategy trainingStrategy)
        {
            _trainingStrategy = trainingStrategy;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public int TrainingCost() => _trainingStrategy.GetTrainignCost();
        public IEnumerable<string> Courses() => _trainingStrategy.GetCourses();


        // many more
    }

    public interface ITrainingStrategy
    {
        int GetTrainignCost();

        IEnumerable<string> GetCourses();

    }

    public class PythonTrainingStrategy : ITrainingStrategy
    {
        public int GetTrainignCost()
        {
            return 100;
        }

        public IEnumerable<string> GetCourses()
        {
            return new List<string> { "basic python", "py sql", "Dyngo" };
        }
    }
 
    public class GoLangTrainingStrategy : ITrainingStrategy
    {
        public int GetTrainignCost()
        {
            return 150;
        }

        public IEnumerable<string> GetCourses()
        {
            return new List<string> { "basic Go" };
        }

    }

   

}
