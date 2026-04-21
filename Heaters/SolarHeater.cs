using IceCity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Heaters
{
    internal class SolarHeater: HeaterBase, IHeater
    {
        protected override double FailureChance => 0.05;

        public SolarHeater(double powerValue) : base(powerValue)
        {
        }

        public override double CalculateEffectivePower()
        {
            return PowerValue * 1.2;
        }

        
    }
}
