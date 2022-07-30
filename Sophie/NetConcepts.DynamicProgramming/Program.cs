using Core;
using Core.Contracts;
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

            // get all members, methods, properties, cons of training class

            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var assembly = Assembly.LoadFile(@"C:\Users\Sophie Anne Busog\source\repos\Training\AdvanceNetConcepts\Sophie\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");

            //var type = assembly.GetType("NetConcepts.Model.Models.Training");

            //var members = type.GetMembers(bindingFlags);
            //foreach (var member in members)
            //{
            //    Console.WriteLine(member.Name);
            //}

            //Console.WriteLine($"Type { type.Name }");

            //var methods = type.GetMethods(bindingFlags);
            //foreach (var method in methods)
            //{
            //    Console.WriteLine(method.Name);
            //}

            //var properties = type.GetProperties(bindingFlags);
            //foreach (var propertie in properties)
            //{
            //    Console.WriteLine(propertie.Name);
            //}

            //var contructors = type.GetConstructors(bindingFlags);
            //foreach (var contructor in contructors)
            //{
            //    Console.WriteLine(contructor.Name);
            //}

            // get the training type and display , then display all members, methods, properties, cons of training class.
            var companyServiceType = assembly.GetType("NetConcepts.Model.Contracts.CompanyService");
            var companyType = assembly.GetType("NetConcepts.Model.Models.Company");
            var companyMethods = companyServiceType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            var companyInstance = Activator.CreateInstance(companyType);
            var companyServiceInstance = Activator.CreateInstance(companyServiceType, companyInstance);


            var getEmployees = companyMethods.FirstOrDefault(s => s.Name == "GetEmployees").Invoke(companyServiceInstance, null);


            // 1st Assignment to Add new Employee using Reflection.

            //Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            //Console.WriteLine("Enter code:");
            string code = Console.ReadLine();

            object[] myParameters = { name, code };

            var addEmployees = companyMethods.FirstOrDefault(s => s.Name == "AddEmployee");
            var callFunction = addEmployees.Invoke(companyServiceInstance, myParameters);


            //   MEF
            //   Managed Extensible Framework
            //   Plugin / Plugout Architecure

            // Export/ Import
            // Export / ImportMany

            var resolver = new Resolver();
            resolver.Resolve();


            // How to access SMTPMail / AWS Service
            // IMailServce: Register Email Service [SMTP/AWS/ Azure]

            var mailService = Container.Resolve<IMailServce>("SESMailService");
            var result = mailService.SendMail("X", "Y", "", "");

            var loggingService = Container.Resolve<ILoggingService>("SESMailService");
            loggingService.Log(result);

            var azureMailService = Container.Resolve<IMailServce>("AzureMailService");
            var azureResult = azureMailService.SendMail("X", "Y", "", "");
            loggingService.Log(azureResult);


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
