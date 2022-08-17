using System;
using System.IO;
using System.Threading.Tasks;
using NetConcepts.Model.Utilities;

namespace Main
{
    class Program
    {
        //private readonly Math mathObj;


        static async Task Main(string[] args)
        {
            //Print(10);
            //var mathObj = new Math();

            //// Subscribe/ UnSubscribe
            //mathObj.OnSumCalculated += (sender, e) => Console.WriteLine("Sum done");

            //var result = mathObj.Sum(2, 2);
            //Console.WriteLine(result);


            //var stringContObj = new StringJoin();
            //var result1 = stringContObj.Join("FirstName", "LastName");
            //Console.WriteLine(result1);

            var result = await CompanyHelper.CreateCompany("Test", 10);
            Console.ReadKey();
        }

        //private static void Print(int v)
        //{
        //    Console.WriteLine(v);
        //}
    }


    //public class Math
    //{
    //    public event EventHandler OnSumCalculated;

    //    public int Sum(int a, int b)
    //    {
    //        var result = a + b;
    //        OnSumCalculated?.Invoke(this, null);

    //        return result;
    //    }
    //}

    //public class StringJoin
    //{
    //    public string Join(string a, string b) => string.Concat(a, b);
    //}


}
