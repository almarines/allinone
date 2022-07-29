using NetConcepts.Model.Models;
using System;
using System.Linq;
using System.Reflection;

namespace NetConcepts.DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static; 

            var assembly = Assembly.LoadFile(@"C:\Users\juliena\Source\Repos\ashuvviet\AdvanceNetConcepts\Julien\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");
            
            var trainingType = assembly.GetType("NetConcepts.Model.Models.Training");
           
            // get all members, methods, properties, cons of training class

            var members = trainingType.GetMembers(bindingFlags);
            Print(members, "Members");

            var methods = trainingType.GetMethods(bindingFlags);
            Print(methods, "Methods");

            var properties = trainingType.GetProperties(bindingFlags);
            Print(properties, "Properties");

            var constructor = trainingType.GetConstructors(bindingFlags);
            Print(constructor, "Constructor");

            var events = trainingType.GetEvents(bindingFlags);
            Print(events, "Events");

            Console.ReadLine();
        }
        private static void Print(MemberInfo[] companyFields, string v)
        {
            Console.WriteLine(v);
            foreach (var item in companyFields)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("********");
        }
    }
}
