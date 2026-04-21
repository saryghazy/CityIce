using IceCity.Enums;
using IceCity.Interfaces;
using IceCity.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Factories
{
    public class CostStrategyFactory : ICostStrategyFactory
    {
        public ICostCalculationStrategy CreateStrategy(StrategyType type)
        {
            switch (type)
            {
                case StrategyType.Standard:
                    return new StandardCostStrategy();

                case StrategyType.Eco:
                    return new EcoCostStrategy();

                default:
                    throw new ArgumentException("Invalid strategy type", nameof(type));
            }
        }
    }
}
