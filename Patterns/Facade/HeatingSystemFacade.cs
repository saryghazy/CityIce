using IceCity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Facade
{
    public class HeatingSystemFacade
    {
        private readonly IHeater _heater;
        private readonly IThermostat _thermostat;
        private readonly ITemperatureSensor _temperatureSensor;
        public HeatingSystemFacade(IHeater heater, IThermostat thermostat, ITemperatureSensor temperatureSensor)
        {
            this._heater = heater ?? throw new ArgumentNullException(nameof(heater));
            this._thermostat = thermostat ?? throw new ArgumentNullException(nameof(thermostat));
            this._temperatureSensor = temperatureSensor ?? throw new ArgumentNullException(nameof(temperatureSensor));
        }
        public void ControlHeating(double desiredTemperature)
        {
            _thermostat.SetDesiredTemperature(desiredTemperature);

            double current = _temperatureSensor.GetCurrentTemperature();

            if (current < desiredTemperature)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }
    }
}

