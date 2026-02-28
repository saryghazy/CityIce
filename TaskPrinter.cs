using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class TaskPrinter
    {
        public static async Task PrintLastMonthDailyUsageWithTasks(House house)
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
                    Console.WriteLine($"{u.Date:yyyy-MM-dd} | Hours={u.WorkingHours:F2} | HeaterVal={u.HeaterValue} | Task={Task.CurrentId}");
                }
            }

            var tasks = new[]
            {
                Task.Run(() => PrintUsage()),
                Task.Run(() => PrintUsage())
            };
            await Task.WhenAll(tasks);
        }
    }
}
