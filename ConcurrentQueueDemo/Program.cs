using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentQueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // QueueDemo();

            //ConcurrentQueueDemo();

            //ConcurrentStackDemo();

            //ConcurrentBagDemo();

            IProducerConsumerCollection<string> shirts = new ConcurrentQueue<string>();
            shirts.TryAdd("PluralSight");
            shirts.TryAdd("WordPress");
            shirts.TryAdd("Code School");

            Console.WriteLine($"After enqueuing, count = {shirts.Count.ToString()}");


            bool success = shirts.TryTake(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving {item1}");
            else
                Console.WriteLine("queue was empty");

             

            Console.WriteLine($"Enumerating...");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\r\nAfter enumerating, count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentBagDemo()
        {
            var shirts = new ConcurrentBag<string>();
            shirts.Add("PluralSight");
            shirts.Add("WordPress");
            shirts.Add("Code School");

            Console.WriteLine($"After enqueuing, count = {shirts.Count.ToString()}");


            bool success = shirts.TryTake(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving {item1}");
            else
                Console.WriteLine("queue was empty");

            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine($"Peeking {item2}");
            else
                Console.WriteLine("queue is empty");

            Console.WriteLine($"Enumerating...");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\r\nAfter enumerating, count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentStackDemo()
        {
            var shirts = new ConcurrentStack<string>();
            shirts.Push("PluralSight");
            shirts.Push("WordPress");
            shirts.Push("Code School");

            Console.WriteLine($"After enqueuing, count = {shirts.Count.ToString()}");


            bool success = shirts.TryPop(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving {item1}");
            else
                Console.WriteLine("queue was empty");

            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine($"Peeking {item2}");
            else
                Console.WriteLine("queue is empty");

            Console.WriteLine($"Enumerating...");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\r\nAfter enumerating, count = {shirts.Count.ToString()}");
        }

        private static void ConcurrentQueueDemo()
        {
            var shirts = new ConcurrentQueue<string>();
            shirts.Enqueue("PluralSight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine($"After enqueuing, count = {shirts.Count.ToString()}");


            bool success = shirts.TryDequeue(out string item1);
            if (success)
                Console.WriteLine($"\r\nRemoving {item1}");
            else
                Console.WriteLine("queue was empty");

            success = shirts.TryPeek(out string item2);
            if (success)
                Console.WriteLine($"Peeking {item2}");
            else
                Console.WriteLine("queue is empty");

            Console.WriteLine($"Enumerating...");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\r\nAfter enumerating, count = {shirts.Count.ToString()}");
        }

        private static void QueueDemo()
        {
            var shirts = new Queue<string>();
            shirts.Enqueue("PluralSight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");

            Console.WriteLine($"After enqueuing, count = {shirts.Count.ToString()}");

            string item1 = shirts.Dequeue();
            Console.WriteLine($"\r\nRemoving {item1}");

            string item2 = shirts.Peek();
            Console.WriteLine($"Peeking {item2}");


            Console.WriteLine($"Enumerating...");
            foreach (var item in shirts)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\r\nAfter enumerating, count = {shirts.Count.ToString()}");
        }
    }
}
