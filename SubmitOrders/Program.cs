using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubmitOrders
{
    class Program
    {
        static readonly object _lockObj = new object();
        static void Main(string[] args)
        {

            var orders = new ConcurrentQueue<string>();
            var ordersWithLock = new Queue<string>();

            //ConcurrentQueueDemo(orders);
            QueueDemoWithLocks(ordersWithLock);
        }

        private static void QueueDemoWithLocks(Queue<string> orders)
        {
            Task task1 = Task.Run(() => PlaceOrderswithLocks(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrderswithLocks(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);


            foreach (var order in orders)
            {
                Console.WriteLine($"ORDER: {order}");
            }
        }

        private static void ConcurrentQueueDemo(ConcurrentQueue<string> orders)
        {
            //PlaceOrders(orders, "Mark");
            //PlaceOrders(orders, "Ramdevi");
            Task task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);


            foreach (var order in orders)
            {
                Console.WriteLine($"ORDER: {order}");
            }
        }

        private static void PlaceOrders(ConcurrentQueue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = string.Format($"{customerName} wants t-shirt {i+1}");
                orders.Enqueue(orderName);
            }
        }

        private static void PlaceOrderswithLocks(Queue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = string.Format($"{customerName} wants t-shirt {i + 1}");
                lock (_lockObj)
                {
                    orders.Enqueue(orderName);
                }
                
            }
        }
    }
}
