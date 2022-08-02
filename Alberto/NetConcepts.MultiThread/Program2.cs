using NetConcepts.Model.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetConcepts.MultiThread
{
    class Program2
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Task task = new Task(() => Display1());
            Task<bool> t2 = Task<bool>.Run(() => {
               return Helper.IsEven(10);
            });


            var factory = Task.Factory.StartNew(() => Display1());
            factory.Wait();

            Task<bool>[] arrayOfTask =
            {
                Task<bool>.Factory.StartNew(() => {
                   return Helper.IsEven(10);
                 }),
                Task<bool>.Factory.StartNew(() => Helper.IsPrime (10))
            };

            Task<IEnumerable<int>> firstTask = Task<IEnumerable<int>>.Factory.StartNew(() =>
            {
                IEnumerable<int> round = Enumerable.Range(1, 10);
                var results = "Result " + round.FirstOrDefault().ToString().ToList();
                return round;
            });

            Task<dynamic> secondTask = firstTask.ContinueWith((r) =>
            {             
                return (dynamic)" Second Display".ToString();
            });



            stopwatch.Stop();
            Console.WriteLine($"total time taken in Ms{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }


         static void Display1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1);
                Console.WriteLine("First Method");
            }
        }

        private static void Display2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1);
                Console.WriteLine("Second Method");
            }
        }

    }
}
