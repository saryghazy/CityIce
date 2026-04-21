using IceCity.Heaters;
using IceCity.Interfaces;
using IceCity.Patterns.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Factories.SystemFactory
{
    internal class StandardSystemFactory:IHeatingSystemFactory
    {
        public IHeater CreateHeater(double powerValue)
        {

            return new GasHeater(powerValue);
        }

        public IThermostat CreateThermostat()
        {

            return new Thermostat();
        }

        public ITemperatureSensor CreateTemperatureSensor()
        {

            return new TemperatureSensor();
        }
    }
}
