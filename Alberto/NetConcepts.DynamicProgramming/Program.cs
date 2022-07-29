using Core;
using Core.Contracts;
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

            var assembly = Assembly.LoadFile(@"C:\_Ashutosh\Trainings\AdvanceNetConcepts\_Ashutosh\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");
            //foreach (var companyType in assembly.GetTypes())
            //{
            //    Console.WriteLine($"Type of Employee {companyType.FullName}");

            //    // Instance Members
            //    var companyFields = companyType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //    //var company = Activator.CreateInstance(typeof(Company));
            //    //var c = Activator.CreateInstance(companyType, company);
            //    Print(companyFields, "Fields");

            //    var companyMethods = companyType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            //    Print(companyMethods, "Methods");

            //    var companyConst = companyType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            //    Print(companyConst, "Constructors");

            //    // Attributes Members
            //    Console.WriteLine("****GetCustomAttributes*****");
            //    var attributes = companyType.GetCustomAttributes();
            //    foreach (var item in attributes)
            //    {
            //        Console.WriteLine(item.GetType().FullName);
            //    }

            //    // Static Members
            //    var staicFields = companyType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            //    Print(staicFields, "Static Fields");

            //}


            //// get the training type and display , then display all members, methods, properties, cons of training class.
            //var companyServiceType = assembly.GetType("NetConcepts.Model.Contracts.CompanyService");
            //var companyType = assembly.GetType("NetConcepts.Model.Models.Company");
            //var companyMethods = companyServiceType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            //var companyInstance = Activator.CreateInstance(companyType);
            //var companyServiceInstance = Activator.CreateInstance(companyServiceType, companyInstance);


            //var getEmployees = companyMethods.FirstOrDefault(s => s.Name == "GetEmployees").Invoke(companyServiceInstance, null);

            // 1st Assignment to Add new Employee using Reflection.


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
