using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDictionaryOps
{
    class Program
    {
        static void Main(string[] args)
        {
            //DictionaryDemo();

            //ConcurrentDictionaryDemo();

            var stock = new ConcurrentDictionary<string, int>();

            bool success = stock.TryAdd("jDays", 4);
            Console.WriteLine($"Add succeeded? {success}");
            success = stock.TryAdd("technologyhour", 3);
            Console.WriteLine($"Add succeeded? {success}");

            Console.WriteLine(string.Format("No. of shirts in stock = {0}", stock.Count));

            success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine($"Add succeeded? {success}");
            success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine($"Add succeeded? {success}");
            stock["buddhistgeeks"] = 5;


            //stock["pluralsight"] = 7;
            
            int psStock = stock.AddOrUpdate("pluralsight", 1, (key, oldValue) => oldValue + 1);
            Console.WriteLine($"New value is {psStock}");
            Console.WriteLine($"stock[pluralsight] = {stock.GetOrAdd("pluralsight",0)}");


            int jDaysValue;
            success = stock.TryRemove("jDays", out jDaysValue);
            if (success)
                Console.WriteLine($"Value removed was {jDaysValue}");


            Console.WriteLine("\r\nEnumerating: ");
            foreach (var keyValPair in stock)
            {
                Console.WriteLine($"{keyValPair.Key}: {keyValPair.Value}");
            }
        }

        private static void ConcurrentDictionaryDemo()
        {
            var stock = new ConcurrentDictionary<string, int>();

            bool success = stock.TryAdd("jDays", 4);
            Console.WriteLine($"Add succeeded? {success}");
            success = stock.TryAdd("technologyhour", 3);
            Console.WriteLine($"Add succeeded? {success}");

            Console.WriteLine(string.Format("No. of shirts in stock = {0}", stock.Count));

            success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine($"Add succeeded? {success}");
            success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine($"Add succeeded? {success}");
            stock["buddhistgeeks"] = 5;


            stock["pluralsight"] = 7;
            Console.WriteLine(string.Format("\r\nstock[pluralsight] = {0}", stock["pluralsight"]));

            int jDaysValue;
            success = stock.TryRemove("jDays", out jDaysValue);
            if (success)
                Console.WriteLine($"Value removed was {jDaysValue}");


            Console.WriteLine("\r\nEnumerating: ");
            foreach (var keyValPair in stock)
            {
                Console.WriteLine($"{keyValPair.Key}: {keyValPair.Value}");
            }
        }

        private static void DictionaryDemo()
        {
            var stock = new Dictionary<string, int>()
            {
                {"jDays", 4 },
                {"technologyhour", 3 }
            };
            Console.WriteLine(string.Format("No. of shirts in stock = {0}", stock.Count));

            stock.Add("pluralsight", 6);
            stock["buddhistgeeks"] = 5;

            stock["pluralsight"] = 7;
            Console.WriteLine(string.Format("\r\nstock[pluralsight] = {0}", stock["pluralsight"]));

            stock.Remove("jDays");

            Console.WriteLine("\r\nEnumerating: ");

            foreach (var keyValPair in stock)
            {
                Console.WriteLine($"{keyValPair.Key}: {keyValPair.Value}");
            }
        }
    }
}
