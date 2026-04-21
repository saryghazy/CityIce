using IceCity.Heaters;
using IceCity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Command
{
    public class StartHeaterCommand : ICommand
    {
        private readonly IHeater _heater;
        public StartHeaterCommand(IHeater heater)
        {
            this._heater = heater;
        }

        public void Execute()
        {
            if (_heater == null)
                throw new InvalidOperationException("Heater is not assigned");

            _heater.TurnOn();
        }
    }
}
