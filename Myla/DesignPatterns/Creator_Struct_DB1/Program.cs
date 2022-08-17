using System;
using System.Collections.Generic;

namespace Creator_Struct_DP1
{

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

    class Program
    {
        static void Main(string[] args)
        {
            var FullTimeEmp = new Employee(new FullTimeEmployeeStrategy());
            var partTimeEmp = new Employee(new PartTimeEmployeeStrategy());

            Console.WriteLine(FullTimeEmp.NumbersOfLeave());
            Console.WriteLine(partTimeEmp.NumbersOfLeave());

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
