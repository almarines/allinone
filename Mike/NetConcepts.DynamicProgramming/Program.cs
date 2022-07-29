﻿using System;
using System.Reflection;

namespace NetConcepts.DynamicProgramming {
  class Program {
    static void Main(string[] args) {

      // get all members, methods, properties, cons of training class

      var assembly = Assembly.LoadFile(@"C:\Temp\netcomm\AdvanceNetConcepts\Mike\NetConcepts.Model\bin\Debug\net5.0\NetConcepts.Model.dll");
      foreach(var companyType in assembly.GetTypes()) {
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

        // Attributes Members
        Console.WriteLine("****GetCustomAttributes*****");
        var attributes = companyType.GetCustomAttributes();
        foreach(var item in attributes) {
          Console.WriteLine(item.GetType().FullName);
        }

        // Static Members
        var staicFields = companyType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
        Print(staicFields, "Static Fields");


        //   MEF
        //   Managed Extensible Framework
        //   Plugin / Plugout Architecure
      }


      // 1st Assignment to Add new Employee using Reflection.

      Console.ReadLine();
    }

    private static void Print(MemberInfo[] companyFields, string v) {
      Console.WriteLine(v);
      foreach(var item in companyFields) {
        Console.WriteLine(item.Name);
      }

      Console.WriteLine("********");
    }
  }
}
