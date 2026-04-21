using IceCity.Interfaces;
using IceCity.Patterns.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Heaters
{
    public class GasHeater : HeaterBase, IHeater
    {


        protected override double FailureChance => 0.2;

        public GasHeater(double powerValues) : base(powerValues)
        {
        }


        public override double CalculateEffectivePower()
        {
            return PowerValue * 0.9;
        }

        public void Attach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify(string message)
        {
            throw new NotImplementedException();
        }
    }
}
