using IceCity.Enums;
using IceCity.Helpers;
using IceCity.Interfaces;
using IceCity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Services
{
    
    public class CostService
    {
        private readonly ICostStrategyFactory _factory;
        public CostService(ICostStrategyFactory factory)
        {
            _factory = factory;
        }
        public double CalculateMonthlyAverageCost(House house, StrategyType type)
        {
            if (house == null)
                throw new ArgumentNullException(nameof(house));
            var strategy = _factory.CreateStrategy(type);
            return strategy.CalculateCost(house);
        }
    }
    
}
