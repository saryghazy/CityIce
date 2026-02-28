using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class HeaterDurationEventArgs: EventArgs
    {
        private DateTime _Date;
        private double _WorkingHours;
        private double _HeaterValue;
        public DateTime Date => _Date;
        public double WorkingHours => _WorkingHours;
        public double HeaterValue => _HeaterValue;
        public HeaterDurationEventArgs(DateTime date, double workingHours, double heaterValue)
        {
            this._Date = date;
            this._WorkingHours = workingHours;
            this._HeaterValue = heaterValue;
        }
    }//دي معموله عشان لما يحصل حدث معين في ال heater duration يقدر يمرر البيانات دي مع الحدث عشان نستخدمها في ال report او اي مكان تاني محتاجها
}
