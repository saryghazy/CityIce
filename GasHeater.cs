using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class GasHeater: HeaterBase
    {
        public GasHeater(double powerValues) : base(powerValues)
        {
        }

       
        public override double CalculateEffectivePower()
        {
            return PowerValue * 0.9; 
        }
    }
}
