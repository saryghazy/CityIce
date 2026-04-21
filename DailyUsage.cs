using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class DailyUsage
    {
        private DateTime _Date;
        private double _WorkingHours;
        private double _HeaterValue;
        public DateTime Date => _Date;
        public double WorkingHours => _WorkingHours;
        public  double HeaterValue => _HeaterValue;
        public DailyUsage(DateTime date, double workingHours , double heaterValue)
        {
            this._Date = date;
            this._WorkingHours = workingHours;
            this._HeaterValue = heaterValue;
        }
    }
}
