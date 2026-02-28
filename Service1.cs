using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    
    internal class Service1
    {
        

        public double CalculateTotalWorkingHours(House house)
        {
            double totalHours = 0;
            foreach (var usage in house.DailyUsages)
            {
                totalHours += usage.WorkingHours;
            }
            return totalHours;
        }
       
        public double CalculateMedianHeaterValue(House house)
        {
            List<double> heaterValues = new List<double>();
            foreach (var value in house.DailyUsages)
            {
                heaterValues.Add(value.HeaterValue);
            }
            heaterValues.Sort();
            int count = heaterValues.Count;
            if (count.IsEven())
            {
                return (heaterValues[heaterValues.Count / 2 - 1] + heaterValues[heaterValues.Count / 2]) / 2.0;
            }
            else
            {
                return heaterValues[heaterValues.Count / 2];
            }
        }
        public double CalculateMonthlyAverageCost(House house)
        {
            double WorkingHours = CalculateTotalWorkingHours (house);
            double median = CalculateMedianHeaterValue(house);
            double averageCost = median * ( WorkingHours / 24 * house.GetDaysInMonth());
            return averageCost;


        }

    }
}
