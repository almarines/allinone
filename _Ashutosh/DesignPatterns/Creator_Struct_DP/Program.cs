using System;
using System.Collections.Generic;

namespace Creator_Struct_DP
{ 
    class Program
    {
        static void Main(string[] args)
        {
            // Strategy
            //var FullTimeEmp = new Employee(new FullTimeEmployeeStrategy());
            //var partTimeEmp = new Employee(new PartTimeEmployeeStrategy());

            //Console.WriteLine(FullTimeEmp.NumbersOfLeave());
            //Console.WriteLine(partTimeEmp.NumbersOfLeave());


            // factory
            //var fullTimeEmp = EmployeeFactory.Create("FullTime");
            //var partTimeEmp = EmployeeFactory.Create("PartTime");

            // Absract factory

            var africa = new AfricaFactory();
            var AfricaAgency = new AnimalAgency(africa);
            AfricaAgency.Create();
            AfricaAgency.Run();


            var americafactory = new AmericaFactory();
            var AmericanAgency = new AnimalAgency(americafactory);
            AmericanAgency.Create();
            AmericanAgency.Run();

            Console.ReadKey();
        }
    }

    #region Strategy Pattern
    //public interface IEmployeeStrategy
    //{
    //    int NumbersOfLeave();
    //    string GetInsurance();
    //    string Contract();
    //}

    //public class FullTimeEmployeeStrategy : IEmployeeStrategy
    //{
    //    public string Contract()
    //    {
    //        return "Full Time contract";
    //    }

    //    public string GetInsurance()
    //    {
    //        return "XX";
    //    }

    //    public int NumbersOfLeave()
    //    {
    //        return 10;
    //    }
    //}

    //public class PartTimeEmployeeStrategy : IEmployeeStrategy
    //{
    //    public string Contract()
    //    {
    //        return "Part Time contract";
    //    }

    //    public string GetInsurance()
    //    {
    //        return "X";
    //    }

    //    public int NumbersOfLeave()
    //    {
    //        return 5;
    //    }
    //}

    //public class Employee
    //{
    //    private readonly IEmployeeStrategy employeeStrategy;

    //    public Employee(IEmployeeStrategy employeeStrategy)
    //    {
    //        this.employeeStrategy = employeeStrategy;
    //    }

    //    public string Name { get; set; }

    //    public int Id { get; set; }

    //    public int NumbersOfLeave() => this.employeeStrategy.NumbersOfLeave();
    //    public string GetInsurance() => this.employeeStrategy.GetInsurance();
    //    public string Contract() => this.employeeStrategy.Contract();

    //    // many more
    //}

    #endregion

    #region Factory pattern

    //public class Employee
    //{

    //}

    //public class FullTimeEmployee : Employee
    //{
    //    public FullTimeEmployee()
    //    {

    //    }
    //}

    //public class PartTimeEmployee : Employee
    //{

    //}

    //public class EmployeeFactory
    //{
    //    public static Employee Create(string typeOfEmployee)
    //    {
    //        switch (typeOfEmployee)
    //        {
    //            case "FullTime":
    //                return new FullTimeEmployee();
    //            case "PartTime":
    //                return new PartTimeEmployee();
    //            default:
    //                return null;
    //        }
    //    }
    //}


    #endregion

    #region Abstract Factory

    public class AnimalAgency
    {
        private readonly ContinentFactory continentFactory;
        private Carnivore carnivore;
        private Herbivore harbivore;

        public AnimalAgency(ContinentFactory continentFactory)
        {
            this.continentFactory = continentFactory;
        }

        public void Create()
        {
            this.carnivore = this.continentFactory.CreateCarnivore();
            this.harbivore = this.continentFactory.CreateHerbivore();
        }

        public void Run()
        {
            this.carnivore.Eat(this.harbivore);
        }
    }

    public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    public abstract class Herbivore
    {
        public abstract void Eat();
    }

    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    public class Wildebeest : Herbivore
    {
        public override void Eat()
        {
            Console.WriteLine("Inside Wildebeest");
        }
    }

    public class Bison : Herbivore
    {
        public override void Eat()
        {
            Console.WriteLine("Inside bison");
        }
    }

    public class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    public class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    public class AfricaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
    }

    public class AmericaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
    }

    #endregion
}
