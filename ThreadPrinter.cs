using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class ThreadPrinter
    {
        public static void PrintLastMonthDailyUsageWithThreads(House house)
        {
            var lastMonth = house.Month;
            List<DailyUsage> LastMonthDailyUsage = new List<DailyUsage>();
            foreach (var dailyUsage in house.DailyUsages)
            {
                if ((MonthEnum)dailyUsage.Date.Month == lastMonth)
                {
                    LastMonthDailyUsage.Add(dailyUsage);
                }
            }
            void PrintUsage()
            {
                foreach(var u in LastMonthDailyUsage)
                {
                    Console.WriteLine($"{u.Date:yyyy-MM-dd} | Hours={u.WorkingHours:F2} | HeaterVal={u.HeaterValue} | Thread={Thread.CurrentThread.ManagedThreadId}");

                }

            }
            Thread t1 = new Thread(PrintUsage);
            Thread t2 = new Thread(PrintUsage);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
        
    }
}
