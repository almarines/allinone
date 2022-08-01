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


        static void Main(string[] args)
        {
            
            //var obj = new Program();

            //obj.DisplayA();
            //obj.DisplayB();

            Parallel.Invoke(() => DisplayA(), () => DisplayB());
            Console.ReadKey();


        }
    }
}
