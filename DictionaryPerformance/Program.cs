using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DictionaryPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            //int dictSize = 1000000;
            //SingleThreadBenchmark(dictSize);
            //MultiThreadedBenchmark(dictSize);

            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 0);
            stock.TryAdd("Code School", 0);
            stock.TryAdd("Buddhist Geeks", 0);

            foreach (var shirt in stock)
            {
                stock.AddOrUpdate("jDays", 0, (key, value) => value + 1);
                Console.WriteLine($"{shirt.Key} : {shirt.Value}");
            }
        }

        private static void MultiThreadedBenchmark(int dictSize)
        {
            Console.WriteLine("\r\nConcurrentDictionary, multiple threads: ");
            var dict = new ConcurrentDictionary<int, int>();
            ParallelBenchmark.TimeDictParallel(dict, dictSize);
        }

        private static void SingleThreadBenchmark(int dictSize)
        {
            

            Console.WriteLine("Dictionary, single thread: ");
            var dict = new Dictionary<int, int>();
            DictionaryPerformance.SingleThreadBenchmark.TimeDict(dict, dictSize);

            Console.WriteLine("\r\nConcurrentDictionary, single thread: ");
            var dict2 = new ConcurrentDictionary<int, int>();
            DictionaryPerformance.SingleThreadBenchmark.TimeDict(dict2, dictSize);
        }
    }
}
