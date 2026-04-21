using IceCity.Helpers;
using IceCity.Interfaces;
using IceCity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Strategies
{
    public class EcoCostStrategy : BaseCostCalculationStrategy
    {
        public override double CalculateCost(House house)
        {
            var totalWorkingHours = CalculateTotalWorkingHours(house);
            var medianHeaterValue = CalculateMedianHeaterValue(house);
            return medianHeaterValue * (totalWorkingHours / 24 * house.GetDaysInMonth()) * 0.8;
        }

        
    }
}
