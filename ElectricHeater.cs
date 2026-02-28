using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class ElectricHeater:HeaterBase
    {
        public ElectricHeater(double powerValue): base(powerValue)
        {
            
        }
        public override double CalculateEffectivePower()
        {
            return PowerValue * 1.1;
        }
    }
}
