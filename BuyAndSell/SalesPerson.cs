using System;
using System.Threading;

namespace BuyAndSell
{
    public class SalesPerson
    {
        public string Name { get; private set; }

        public SalesPerson(string id)
        {
            this.Name = id;
        }

        public void Work(StockController stockController, TimeSpan workDay)
        {
            Random rand = new Random(Name.GetHashCode());
            DateTime start = DateTime.Now;

            while(DateTime.Now - start < workDay)
            {
                //Thread.Sleep(rand.Next(100));
                bool buy = (rand.Next(6) == 0);
                string itemName = Program.AllShirtNames[rand.Next(Program.AllShirtNames.Count)];

                if (buy)
                {
                    int quantity = rand.Next(9) + 1;
                    stockController.BuyStock(itemName, quantity);
                    //DisplayPurchase(itemName, quantity);
                }
                else
                {
                    bool success = stockController.TrySellItem(itemName);
                    //DisplaySaleAttempt(success, itemName);
                }
            }
            Console.WriteLine($"SalesPerson {this.Name} signing off");
        }

        private void DisplaySaleAttempt(bool success, string itemName)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            if(success)
                Console.WriteLine($"Thread {threadId}: {this.Name} sold {itemName}");
            else
                Console.WriteLine($"Thread {threadId}: {this.Name} Out of Stock {itemName}!");
        }

        private void DisplayPurchase(string itemName, int quantity)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {this.Name} bought {quantity} of {itemName}");
        }
    }
}