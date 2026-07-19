using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Models
{
    public class DailyUsage
    {
        public Guid DailyUsageId { get; set; }   // PK

        public Guid HouseId { get; set; }        // FK -> House.HouseId

        public Guid HeaterId { get; set; }       // FK -> Heater.HeaterId

        public DateTime UsageDate { get; set; }  // date only

        public double HoursWorked { get; set; }  // 0..24

        public double HeaterValue { get; set; }  // recorded value for that day
    }
}
