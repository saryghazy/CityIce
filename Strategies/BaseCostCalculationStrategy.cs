using IceCity.Helpers;
using IceCity.Interfaces;
using IceCity.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace IceCity.Strategies
{
    public abstract class BaseCostCalculationStrategy:ICostCalculationStrategy
    {
        protected double CalculateTotalWorkingHours(House house)
        {
            double totalHours = 0;
            foreach (var usage in house.DailyUsages)
            {
                totalHours += usage.WorkingHours;
            }
            return totalHours;
        }
        protected double CalculateMedianHeaterValue(House house)
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

        public abstract  double CalculateCost(House house);
    }
}
