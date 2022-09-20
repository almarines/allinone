using System;
using System.Collections.Generic;

namespace Creator_Struct_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            //var FullTimeEmp = new Employee(new FullTimeEmployeeStrategy());
            //var partTimeEmp = new Employee(new PartTimeEmployeeStrategy());

            //Console.WriteLine(FullTimeEmp.NumbersOfLeave());
            //Console.WriteLine(partTimeEmp.NumbersOfLeave());


            //var pythonTraining = new Training(new PythonTrainingStrategy());
            //var goLangTraining = new Training(new GoLangTrainingStrategy());

            //Console.WriteLine($"Python training cost: {pythonTraining.GetTrainingCost()}");
            //Console.WriteLine("Courses:");
            //Console.WriteLine(string.Join(Environment.NewLine, pythonTraining.GetCourses()));
            //Console.WriteLine($"\nGoLang training cost: {goLangTraining.GetTrainingCost()}");
            //Console.WriteLine("Courses:");
            //Console.WriteLine(string.Join(Environment.NewLine, goLangTraining.GetCourses()));

            var africa = new AfricaFactory();
            var AfricaAgency = new AnimalAgency(africa);
            AfricaAgency.Create();
            AfricaAgency.Run();

            var americafactory = new AmericaFactory();
            var AmericanAgency = new AnimalAgency(americafactory);
            AmericanAgency.Create();
            AmericanAgency.Run();
            
            // Bridge Pattern
            //var abstractor = new Abstraction();
            //abstractor.Implementor = new Implementor1();
            //abstractor.Operation();

            // Decorator Pattern

            ConcreateComponent c = new ConcreateComponent();
            ConcreateDecorator d = new ConcreateDecorator();
            d.SetComponent(c);
            d.Operation();

            Console.ReadKey();
        }
    }

    #region Training Strategy
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
    #endregion

    #region EmployeeStrategy
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


    #region Bridge Pattern

    public class Abstraction
    {
        protected IImplementor implementor;
        public IImplementor Implementor
        {
            set { implementor = value; }
        }
        public virtual void Operation()
        {
            implementor.Operation();
        }
    }

    public interface IImplementor
    {
        void Operation();
    }

    public class Implementor1 : IImplementor
    {
        public void Operation()
        {
            Console.WriteLine("Implementor 1");
        }
    }

    public class Implementor2 : IImplementor
    {
        public void Operation()
        {
            Console.WriteLine("Implementor 2");
        }
    }


    #endregion

    #region Decorator

    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreateComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Inside ConcreateComponent Operation");
        }
    }

    public abstract class Decorator : Component
    {
        private Component Component;

        public void SetComponent(Component c)
        {
            this.Component = c;
        }

        public override void Operation()
        {
            if (this.Component != null)
            {
                this.Component.Operation();
            }
        }
    }

    public class ConcreateDecorator : Decorator
    {
        public override void Operation()
        {
            Console.WriteLine("Inside ConcreateDecorator Operation");
            base.Operation();
        }
    }

    #endregion
}
