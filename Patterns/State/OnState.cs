using IceCity.Heaters;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.State
{
    public class OnState : IHeaterState
    {
        
            private readonly HeaterBase _heater;
            public OnState(HeaterBase heater)
            {
                this._heater = heater;
            }
        public void TurnOff()
        {
            try
            {
                _heater.Close();
                _heater.SetState(new OffState(_heater));
            }
            catch (HeaterFailedException)
            {
                _heater.SetState(new FaultState(_heater));

            }
        }

        public void TurnOn()
            {
                Console.WriteLine("Heater is already ON");
            }
        
    }
}
