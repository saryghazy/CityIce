using Linq.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Services
{
    public static class UtilityFunctions
    {
        public static double CalculateCost(double power , double hours)
        {
              return power * hours;
        }
        public static void AddUsage(DailyUsage dailyUsage) 
        { 
            Repository.DailyUsages.Add(dailyUsage);
        }
    }
}
