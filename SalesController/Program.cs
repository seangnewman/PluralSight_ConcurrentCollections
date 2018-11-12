using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesBonuses
{
    class Program
    {
        public static readonly List<string> AllShirtNames = new List<string>
            {
                "technologyhour", "Code School", "jDays", "buddhistgeeks", "iGeek"
            };

        static void Main(string[] args)
        {
            StaffLogForBonuses staffLogs = new StaffLogForBonuses();
            ToDoQueue toDoQueue = new ToDoQueue(staffLogs);

            SalesPerson[] people = { new SalesPerson("Sahil"),
                                     new SalesPerson("Peter"),
                                     new SalesPerson("Juliette"),
                                     new SalesPerson("Xavier") };

            StockController controller = new StockController(toDoQueue);


            TimeSpan workDay = new TimeSpan(0, 0, 1);

            Task t1 = Task.Run(() => new SalesPerson("Sahil").Work(controller, workDay));
            Task t2 = Task.Run(() => new SalesPerson("Peter").Work(controller, workDay));
            Task t3 = Task.Run(() => new SalesPerson("Juliette").Work(controller, workDay));
            Task t4 = Task.Run(() => new SalesPerson("Xavier").Work(controller, workDay));

            Task bonusLogger = Task.Run( () => toDoQueue.MonitorAndLogTrades());
            Task bonusLogger2 = Task.Run(() => toDoQueue.MonitorAndLogTrades());

            Task.WaitAll(t1, t2, t3, t4);
            toDoQueue.CompleteAdding();
            Task.WaitAll(bonusLogger, bonusLogger2);


            controller.DisplayStatus();
            staffLogs.DisplayReport(people);
        }
    }
}
