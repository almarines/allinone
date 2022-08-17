using System;
using System.Collections.Generic;

namespace Creator_Struct_DP
{
    public interface ITrainingStrategy
    {
        int GetTrainingCost();
        IEnumerable<string> GetCourses();
    }

    public class Training
    {
        private readonly ITrainingStrategy _trainingStrategy;

        public Training(ITrainingStrategy trainingStrategy)
        {
            _trainingStrategy = trainingStrategy;
        }

        public int GetTrainingCost() => _trainingStrategy.GetTrainingCost();

        public IEnumerable<string> GetCourses() => _trainingStrategy.GetCourses();

    }

    public class PythonTrainingStrategy : ITrainingStrategy
    {
        public int GetTrainingCost()
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
        public int GetTrainingCost()
        {
            return 150;
        }

        public IEnumerable<string> GetCourses()
        {
            return new List<string> { "basic Go" };
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //var FullTimeEmp = new Employee(new FullTimeEmployeeStrategy());
            //var partTimeEmp = new Employee(new PartTimeEmployeeStrategy());

            //Console.WriteLine(FullTimeEmp.NumbersOfLeave());
            //Console.WriteLine(partTimeEmp.NumbersOfLeave());


            var pythonTraining = new Training(new PythonTrainingStrategy());
            var goLangTraining = new Training(new GoLangTrainingStrategy());

            Console.WriteLine($"Python training cost: {pythonTraining.GetTrainingCost()}");
            Console.WriteLine("Courses:");
            Console.WriteLine(string.Join(Environment.NewLine, pythonTraining.GetCourses()));
            Console.WriteLine($"\nGoLang training cost: {goLangTraining.GetTrainingCost()}");
            Console.WriteLine("Courses:");
            Console.WriteLine(string.Join(Environment.NewLine, goLangTraining.GetCourses()));

            Console.ReadKey();
        }
    }

    public interface IEmployeeStrategy
    {
        int NumbersOfLeave();
        string GetInsurance();
        string Contract();
    }

    public class FullTimeEmployeeStrategy : IEmployeeStrategy
    {
        public string Contract()
        {
            return "Full Time contract";
        }

        public string GetInsurance()
        {
            return "XX";
        }

        public int NumbersOfLeave()
        {
            return 10;
        }
    }

    public class PartTimeEmployeeStrategy : IEmployeeStrategy
    {
        public string Contract()
        {
            return "Part Time contract";
        }

        public string GetInsurance()
        {
            return "X";
        }

        public int NumbersOfLeave()
        {
            return 5;
        }
    }

    public class Employee
    {
        private readonly IEmployeeStrategy employeeStrategy;

        public Employee(IEmployeeStrategy employeeStrategy)
        {
            this.employeeStrategy = employeeStrategy;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public int NumbersOfLeave() => this.employeeStrategy.NumbersOfLeave();
        public string GetInsurance() => this.employeeStrategy.GetInsurance();
        public string Contract() => this.employeeStrategy.Contract();

        // many more
    }

    //public class FullTimeEmployee : Emplpoyee
    //{
    //    public FullTimeEmployee()
    //    {

    //    }
    //}

    //public class PartTimeEmployee : Emplpoyee
    //{
       
    //}
}
