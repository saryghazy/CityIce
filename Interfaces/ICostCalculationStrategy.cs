using IceCity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Interfaces
{
    public interface ICostCalculationStrategy
    {
        double CalculateCost(House house);


    }
}
