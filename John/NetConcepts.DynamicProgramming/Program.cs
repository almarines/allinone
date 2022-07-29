using System;
using System.Linq;
using System.Reflection;

namespace NetConcepts.DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //var company = new Company();
            //var empService = new EmployeeService(company);

            //foreach (var emp in empService.GetEmployees())
            //{
            //    Console.WriteLine(emp.ToString());
            //}

            //var companyType = typeof(CompanyService);

            var assembly = Assembly.LoadFile(@"C:\Workspaces\Training\AdvanceNetConcepts\John\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");
            foreach (var companyType in assembly.GetTypes())
            {
                Console.WriteLine($"Type of Employee {companyType.FullName}");

                // Instance Members
                var companyFields = companyType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                //var company = Activator.CreateInstance(typeof(Company));
                //var c = Activator.CreateInstance(companyType, company);
                Print(companyFields, "Fields");


                var companyMethods = companyType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                Print(companyMethods, "Methods");

                var companyConst = companyType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
                Print(companyConst, "Constructors");


                // Static Members
                var staicFields = companyType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
                Print(staicFields, "Static Fields");


                // MEF
                // Managed Extensible Framework
                // Plugin/ Plugout Architecure
            }


            // get all members, methods, properties, cons of training class

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
