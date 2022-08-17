using Core.Utilities;
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
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            #region Session 2
            //Task t1 = new Task(() => Display1());
            //t1.Start();

            //t1.Wait();


            //var t1 = Task.Run(() => Display1());
            //t1.Wait();

            //Task<bool> t2 = Task<bool>.Run(() => 
            //{
            //    return Helper.IsEven(10);
            //    });

            //t2.Wait();
            //Console.WriteLine(t2.Result);



            // task.factory

            //var t1 = Task.Factory.StartNew(() => Display1());
            //t1.Wait();

            //Task<bool>[] arrayOfTask =
            //{
            //    Task<bool>.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Even number");
            //        return Helper.IsEven(10);
            //        }),

            //     Task<bool>.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Odd number");
            //        return Helper.IsOdd(10);
            //        }),

            //       Task<bool>.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Prime number");
            //        return Helper.IsPrime(10);
            //        }),
            //};

            //Task.WaitAll(arrayOfTask);

            // Localization / Support of Muti language.
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");


            //// for all work threads in your application
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr-FR");
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fr-FR");

            // Task.Continuation           
            //Task<IEnumerable<int>> firstTask = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"Executing First Task");
            //    var numbers = Enumerable.Range(1, 10);
            //    return numbers;
            //});

            //Task<Dictionary<int, bool>> secondTask = firstTask.ContinueWith((t) =>
            //{
            //    Console.WriteLine($"Executing Second Task");
            //    var dic = new Dictionary<int, bool>();
            //    foreach (var item in t.Result)
            //    {
            //        dic.Add(item, Helper.IsPrime(item));
            //        //if(Helper.IsPrime(item))
            //        //{
            //        //    //Console.WriteLine("Prime Number" + item);
            //        //}
            //    }

            //    return dic;
            //});

            //Task thridTask = secondTask.ContinueWith((secondTask) =>
            //{
            //    Console.WriteLine($"Executing Thrid Task");
            //    foreach (var item in secondTask.Result)
            //    {
            //        if(item.Value)
            //        Console.WriteLine($"{item.Key} is Prime Number");
            //        Console.WriteLine($"{item.Key} is Non Prime Number");
            //    }
            //});

            // Task Cancellation

            //var tokenSource = new CancellationTokenSource();
            //CancellationToken token = tokenSource.Token;
            //var t1 = Task.Factory.StartNew(() =>
            //{
            //    Display1(token);
            //}
            // , token);

            //Thread.Sleep(100);
            //tokenSource.Cancel();


            //var task = Task.Run(() =>
            //{



            //});


            // Child Task
            //Task parentTask = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"Executing Parent Task");
            //    var childTask = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine($"Executing Child Task");
            //    }, TaskCreationOptions.AttachedToParent);
            //});

            //parentTask.Wait();

            // Exception Handling [ Child Task promiting exception parent task]
            // parent task exception
            //var task = Task.Run(() => throw new InvalidOperationException("This exception is expected!"));

            //try
            //{
            //    task.Wait();
            //}
            //catch (AggregateException ae)
            //{
            //    foreach (var ex in ae.InnerExceptions)
            //    {
            //        // Handle the custom exception.
            //        if (ex is InvalidOperationException)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }
            //        // Rethrow any other exception.
            //        else
            //        {
            //            throw ex;
            //        }
            //    }
            //}


            // child task exception
            //Task parentTask = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"Executing Parent Task");
            //    var childTask = Task.Factory.StartNew(() =>
            //    {
            //        throw new InvalidOperationException("This exception is expected!");
            //    }, TaskCreationOptions.AttachedToParent);
            //});

            //try
            //{
            //    parentTask.Wait();
            //}
            //catch (AggregateException ae)
            //{
            //    foreach (var ex in ae.Flatten().InnerExceptions)
            //    {
            //        // Handle the custom exception.
            //        if (ex is InvalidOperationException)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }
            //        // Rethrow any other exception.
            //        else
            //        {
            //            throw ex;
            //        }
            //    }
            //}
            #endregion

            #region Session 3
            //var result = await ServiceHelper.ClientApi<bool>("https://google.com", HttpMethod.Get, null);
            //if (result)
            //{
            //    await Display1();
            //}
            #endregion


            #region Second Activity
            //var result = await CompanyHelper.CreateCompany("Test", 10);
            var list2 = GetNumbers();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            #endregion


            stopwatch.Stop();
            Console.WriteLine($"total time taken in Ms{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

        private static IEnumerable<int> GetNumbers()
        {
            foreach (var item in Enumerable.Range(0, 10))
            {
                yield return item;
            }
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

        //private static void Display1(CancellationToken ct)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(1);

        //        Console.WriteLine("First Method");
        //    }

        //    if (ct.IsCancellationRequested)
        //    {
        //        ct.ThrowIfCancellationRequested();
        //    }
        //}

        //private static void Display2()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(1);
        //        Console.WriteLine("Second Method");
        //    }
        //}
    }
}
