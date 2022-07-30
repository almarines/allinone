using Core;
using Core.Contracts;
using NetConcepts.Model.Contracts;
using System;
using System.Linq;
using System.Reflection;
//using Core;
//using Core.Contracts;

namespace NetConcepts.DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = args;

            // Exercise1_Reflection(); // Completed
            Exercise2_MEH();

            Console.ReadLine();
        }

        private static void Exercise1_Reflection() {

            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var assembly = Assembly.LoadFile(@"C:\Source\Workspace\Training\NetCom\Gervel\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");

            var trainingType = assembly.GetType("NetConcepts.Model.Models.Training");

            Print(trainingType.FullName.ToString(), "'Training' Type");

            var members = trainingType.GetMembers(bindingFlags);
            Print(members, "Members");

            var methods = trainingType.GetMethods(bindingFlags);
            Print(methods, "Methods");

            var properties = trainingType.GetProperties(bindingFlags);
            Print(properties, "Properties");
        }

        private static void Exercise2_MEH() {
            var resolver = new Resolver();
            resolver.Resolve();

			var mailService = Container.Resolve<IMailService>("AzureMailService");
			var result = mailService.SendMail("Sender", "Receiver", "Subject", "Body");

			var loggingService = Container.Resolve<ILoggingService>("ConsoleLogger");
			loggingService.Log(result);
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
