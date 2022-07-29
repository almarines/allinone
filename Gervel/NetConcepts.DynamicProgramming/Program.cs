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
            _ = args;
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var assembly = Assembly.LoadFile(@"C:\Source\Workspace\Training\NetCom\Gervel\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");

            var trainingType = assembly.GetType("NetConcepts.Model.Models.Training");

            Print(trainingType.Name.ToString(), "'Training' Type");

            var members = trainingType.GetMembers(bindingFlags);
            Print(members, "Members");

            var methods = trainingType.GetMethods(bindingFlags);
            Print(methods, "Methods");

            var properties = trainingType.GetProperties(bindingFlags);
            Print(properties, "Properties");

            Console.ReadLine();
        }

        private static void Print(string content, string label) {
            Console.WriteLine($"{ label }:\n");

            Console.WriteLine(content);

            Console.WriteLine("\n********\n");
        }

        private static void Print(MemberInfo[] companyFields, string label) {
            Console.WriteLine($"{ label }:\n");

            foreach (var item in companyFields) {
                Console.WriteLine($"\t{ item.Name }");
            }

            Console.WriteLine("\n********\n");
        }
    }
}
