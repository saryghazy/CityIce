using IceCity.Helpers;
using IceCity.Models;
using IceCity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Strategies
{
    public class StandardCostStrategy: BaseCostCalculationStrategy
    {
        public override double CalculateCost(House house)
        {
            var totalWorkingHours = CalculateTotalWorkingHours(house);
            var medianHeaterValue = CalculateMedianHeaterValue(house);
            return medianHeaterValue * (totalWorkingHours / 24 * house.GetDaysInMonth());
        }
        
    }
}
