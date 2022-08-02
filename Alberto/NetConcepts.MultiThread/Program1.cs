using NetConcepts.Model.Utilities;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace NetConcepts.MultiThread
{
   public class Program1 
    {
        private static object lockObj = new object();

        static void DisplayA()
        {
            lock (lockObj)
            {
                for(int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1);
                    Console.WriteLine("Display A");
                }
            }
        }

        static void DisplayB()
        {
            lock (lockObj)
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1);
                    Console.WriteLine("Display B");
                }
            }
        }


        static void Main___(string[] args)
        {

            //var obj = new Program();

            //obj.DisplayA();
            //obj.DisplayB();

            Task task = new Task(() => DisplayA());
            Task<bool> t2 = Task<bool>.Run(() => {
                return Helper.IsEven(10);
            });

            Parallel.Invoke(() => DisplayA(), () => DisplayB());
            Console.ReadKey();


        }
    }
}
