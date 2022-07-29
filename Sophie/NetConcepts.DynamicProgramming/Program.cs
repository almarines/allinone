using NetConcepts.Model.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace NetConcepts.DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {

            static void Main(string[] args)
            {

                // get all members, methods, properties, cons of training class

                var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;


                var assembly = Assembly.LoadFile(@"C:\Users\Sophie Anne Busog\source\repos\Training\AdvanceNetConcepts\Sophie\NetConcepts.DynamicProgramming\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");

                var type = assembly.GetType("NetConcepts.Model.Models.Training");

                var members = type.GetMembers(bindingFlags);
                foreach (var member in members)
                {
                    Console.WriteLine(member.Name);
                }

                Console.WriteLine($"Type { type.Name }");

                var methods = type.GetMethods(bindingFlags);
                foreach (var method in methods)
                {
                    Console.WriteLine(method.Name);
                }

                var properties = type.GetProperties(bindingFlags);
                foreach (var propertie in properties)
                {
                    Console.WriteLine(propertie.Name);
                }

                var contructors = type.GetConstructors(bindingFlags);
                foreach (var contructor in contructors)
                {
                    Console.WriteLine(contructor.Name);
                }

                Console.ReadLine();
            }

        }


    }
}
