using System;
using System.Collections.Concurrent;
using System.Threading;

namespace SalesBonuses
{

    public class StaffLogForBonuses
    {

        private ConcurrentDictionary<SalesPerson, int> _salesByPerson = new ConcurrentDictionary<SalesPerson, int>();
        private ConcurrentDictionary<SalesPerson, int> _purchasesByPerson = new ConcurrentDictionary<SalesPerson, int>();

        public  void ProcessTrade(Trade sale)
        {
            Thread.Sleep(300);
            if (sale.QuantitySold > 0)
                _salesByPerson.AddOrUpdate(sale.Person,
                                            sale.QuantitySold,
                                            (key, oldValue) => oldValue + sale.QuantitySold);
            else
                _purchasesByPerson.AddOrUpdate(sale.Person, 
                                                -sale.QuantitySold, 
                                                (key, oldValue) => oldValue - sale.QuantitySold);
        }

        public void DisplayReport(SalesPerson[] people)
        {
            Console.WriteLine();
            Console.WriteLine("Transactions by salesperson:");

            foreach (var person in people)
            {
                int sales = _salesByPerson.GetOrAdd(person, 0);
                int purchaess = _purchasesByPerson.GetOrAdd(person, 0);

                Console.WriteLine($"{person.Name, 15} sold {sales,3}, bought {purchaess, 3} items, total {sales + purchaess}");
            }
        }
    }
}