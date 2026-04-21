using IceCity.Interfaces;
using IceCity.Patterns.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Factories.SystemFactory
{
    public interface IHeatingSystemFactory
    {
        IHeater CreateHeater(double powerValue);
        IThermostat CreateThermostat();
        ITemperatureSensor CreateTemperatureSensor();
    }
}
