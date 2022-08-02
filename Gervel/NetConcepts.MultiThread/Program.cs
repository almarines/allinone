using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NetConcepts.Model.Utilities;

namespace NetConcepts.MultiThread
{
    class Program {
        public static async Task Main() {

            var company = await CompanyHelper.CreateCompany("KII", 15);

            await Display1();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void SamplePrallel() {
            // 2 million
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForeach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Parallel.ForEach loop  | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.");
        }

        private static async Task Display1() {
            await Display2();
            for (int i = 0; i < 100; i++) {
                Console.WriteLine("First Method");
            }
        }

        private static async Task Display2() {
            for (int i = 0; i < 100; i++) {
                await Task.Delay(1);
                Console.WriteLine("Second Method");
            }
        }

        /// <summary>
        /// GetPrimeList returns Prime numbers by using sequential ForEach
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

        /// <summary>
        /// GetPrimeListWithParallel returns Prime numbers by using Parallel.ForEach
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static IList<int> GetPrimeListWithParallel(IList<int> numbers) {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(numbers, number => {
                if (IsPrime(number)) {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }

        /// <summary>
        /// IsPrime returns true if number is Prime, else false.(https://en.wikipedia.org/wiki/Prime_number)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsPrime(int number) {
            if (number < 2) {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++) {
                if (number % divisor == 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
