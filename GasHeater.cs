using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class GasHeater: HeaterBase
    {
        

        protected override double FailureChance => 0.2;

        public GasHeater(double powerValues) : base(powerValues)
        {
        }

       
        public override double CalculateEffectivePower()
        {
            return PowerValue * 0.9; 
        }
        public void TurnOn()//
        {
            OnOpen();
        }
        public void TurnOff()
        {
            OnClose(DateTime.UtcNow, 0, PowerValue);
        }
    }
}
