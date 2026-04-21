using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Facade
{
    public class Thermostat: IThermostat
    {
        private double _temperature;

        public void SetDesiredTemperature(double temperature)
        {
            _temperature = temperature;
        }
        public double GetDesiredTemperature()
        {
            return _temperature;
        }
    }
}
