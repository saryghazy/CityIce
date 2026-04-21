using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class ElectricHeater:HeaterBase
    {
        

        protected override double FailureChance => 0.1;

        public ElectricHeater(double powerValue): base(powerValue)
        {
            
        }
        public override double CalculateEffectivePower()
        {
            return PowerValue * 1.1;
        }
        
        public void TurnOn()
        {
            
            OnOpen();
        }
        public void TurnOff()
        {
            OnClose(DateTime.UtcNow, 0, PowerValue);
        }
        

    }
}
