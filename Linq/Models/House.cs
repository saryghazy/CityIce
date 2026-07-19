using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Linq.Models
{
    public class House
    {
        public Guid HouseId { get; set; }                // PK

        public Guid OwnerId { get; set; }                // FK -> Owner.OwnerId

        public string Address { get; set; }

        public string CityZone { get; set; }

        public List<Heater> Heaters { get; set; } = new();

        public List<DailyUsage> DailyUsages { get; set; } = new();

    }
}
