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

            var result = await ServiceHelper.ClientApi<bool>("https://google.com", HttpMethod.Get, null);
            if (result)
            {
                await Display1();
            }

            stopwatch.Stop();
            Console.WriteLine($"total time taken in Ms{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

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
