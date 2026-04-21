using IceCity.Heaters;
using IceCity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.State
{
    public class OffState : IHeaterState
    {
        private readonly HeaterBase _heater;
        public OffState(HeaterBase heater)
        {
            this._heater = heater;
        }
        public void TurnOff()
        {
            Console.WriteLine("Heater is already OFF");
        }

        public void TurnOn()
        {
            try
            {
                _heater.Open();
                _heater.SetState(new OnState(_heater));
            }
            catch (HeaterFailedException)
            {
                _heater.SetState(new FaultState(_heater));

            }
        }
    }
}
