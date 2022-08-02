﻿using Core;
using Core.Contracts;
using Core.Extensions;
using NetConcepts.Model.Contracts;
using NetConcepts.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace NetConcepts.DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var empService = new CompanyService(new Model.Models.Company("test"));
            var list = empService.GetEmployees();

            list.AddRange(new List<Employee>());

            //var company = new Company();
            //var empService = new EmployeeService(company);

            //foreach (var emp in empService.GetEmployees())
            //{
            //    Console.WriteLine(emp.ToString());
            //}

            //var companyType = typeof(CompanyService);

            //var assembly = Assembly.LoadFile(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll")));
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


            //    // Static Members
            //    var staicFields = companyType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            //    Print(staicFields, "Static Fields");


            //    // MEF
            //    // Managed Extensible Framework
            //    // Plugin/ Plugout Architecure
            //}


            // get all members, methods, properties, cons of training class
            //PrintTrainingType();

            var resolver = new Resolver();
            resolver.Resolve();


            // How to access SMTPMail / AWS Service
            // IMailServce: Register Email Service [SMTP/AWS/ Azure]

            var mailService = Container.Resolve<IMailServce>("MyMailService");
            var result = mailService.SendMail("X", "Y", "", "");

            var loggingService = Container.Resolve<ILoggingService>("MyTextLogger");
            loggingService.Log(result);

            Container.Resolve<IMailServce>().SendMail();
            Thread.Sleep(60 * 1000);
            Console.WriteLine("Hi");

            Console.ReadLine();
        }

        private static void PrintTrainingType()
        {
            var assembly = Assembly.LoadFile(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll")));

            var trainingType = assembly.GetType("NetConcepts.Model.Models.Training");
            Console.WriteLine($"Type of Employee {trainingType.FullName}");
            Console.WriteLine();

            var companyFields = trainingType.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Print(companyFields, "Members");
            Console.WriteLine();

            var companyMethods = trainingType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Print(companyMethods, "Methods");
            Console.WriteLine();

            var staicFields = trainingType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            Print(staicFields, "Properties");
            Console.WriteLine();

            var companyConst = trainingType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Print(companyConst, "Constructors");
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
