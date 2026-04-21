using IceCity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Interfaces
{
    public interface ICostStrategyFactory
    {
        ICostCalculationStrategy CreateStrategy(StrategyType type);
    }
}
