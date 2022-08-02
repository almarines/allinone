using NetConcepts.Model.Models;
using NetConcepts.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetConcepts.MultiThread {
  class Program {
    static async Task Main(string[] args) {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      var result = await CompanyHelper.CreateCompany("test", 10);

      //await Display1();

      var list2 = GetEmployeeNames(result);
      foreach(var emp in list2) {
        Console.WriteLine(emp);
      }

      var list3 = GetNumbers();
      foreach(var item in list3) {
        Console.WriteLine(item);
      }

      stopwatch.Stop();
      Console.WriteLine($"total time taken in Ms{stopwatch.ElapsedMilliseconds}");
      Console.ReadKey();
    }

    private static IEnumerable<int> GetNumbers() {
      var list = new List<int>();
      foreach(var item in Enumerable.Range(0, 10)) {
        //list.Add(item);
        yield return item;
      }
      //return list;
    }

    private static IEnumerable<string> GetEmployeeNames(Company c) {
      foreach(var item in c.Employees) {
        {
          yield return item.Name;
        }
      }
    }

    private async static Task Display1() {
      await Display2();
      for(int i = 0; i < 100; i++) {
        Console.WriteLine($"First Method {i}");
      }
    }

    private static async Task Display2() {
      for(int i = 0; i < 100; i++) {
        await Task.Delay(1);
        Console.WriteLine($"Second Method {i}");
      }
    }
  }
}
