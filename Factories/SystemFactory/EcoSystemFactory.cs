using IceCity.Heaters;
using IceCity.Interfaces;
using IceCity.Models;
using IceCity.Patterns.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Factories.SystemFactory
{
    public class EcoSystemFactory: IHeatingSystemFactory
    {
        public IHeater CreateHeater(double powerValue)
        {

            return new SolarHeater(powerValue);

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