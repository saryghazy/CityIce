using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Facade
{
    public class TemperatureSensor: ITemperatureSensor
    {
        private readonly Random _random = new();

        public double GetCurrentTemperature()
        {
            return _random.Next(10,35);
        }
    }
}
