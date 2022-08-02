using Core.Utilities;
using NetConcepts.Model.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetConcepts.MultiThread
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //var result = await ServiceHelper.ClientApi<bool>("https://google.com", HttpMethod.Get, null);
            //if (result)
            //{
            //    await Display1();
            //}
            //await CompanyHelper.CreateCompany("MyCompany", 5);

            //await Display1();

            var list2 = GetNumbers();
            foreach (var num in list2)
            {
                Console.WriteLine(num);
            }

            stopwatch.Stop();
            Console.WriteLine($"total time taken in Ms{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

        private static IEnumerable<int> GetNumbers()
        {
            foreach (var item in Enumerable.Range(0, 10))
                yield return item;
        }

        //private static IEnumerable<int> GetNumbers()
        //{
        //    var list = new List<int>();
        //    foreach (var item in Enumerable.Range(0, 10))
        //        list.Add(item);
        //    return list;
        //}

        private static async Task Display1()
        {
            await Display2();
            for (int i = 0; i < 100; i++)
            {               
                Console.WriteLine("First Method");
            }
        }

        private static async Task Display2()
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(1);
                Console.WriteLine("Second Method");
            }
        }
    }
}
