using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.DTOs
{
    internal class UsageDto
    {
        public string Address { get; internal set; }
        public string HeaterType { get; internal set; }
        public DateTime UsageDate { get; internal set; }
        public double HoursWorked { get; internal set; }
    }
}
