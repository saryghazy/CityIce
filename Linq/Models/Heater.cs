using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Models
{
    public class Heater
    {
        public Guid HeaterId { get; set; }       // PK

        public Guid HouseId { get; set; }        // FK -> House.HouseId

        public string HeaterType { get; set; }   // "Electric", "Gas", ...

        public double PowerValue { get; set; }   // numeric power/value

    }
}
