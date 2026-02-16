using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class House
    {
        private int _id;
        private string _address;
        private Owner _owner;
        private MonthEnum _month;
        private List<HeaterBase> _heaters;
        private List<DailyUsage> _dailyUsage;
        public int Id => _id;
        public string Address => _address;
        public Owner Owner => _owner;
        public MonthEnum Month => _month;
        public IReadOnlyList<HeaterBase> Heaters => _heaters;
        public IReadOnlyList<DailyUsage> DailyUsages
        { get
            {
                return _dailyUsage;
            } 
        }
        public House(int id, string address, Owner owner,MonthEnum month)
        {
            this._id = id;
            this._address = address;
            this._owner = owner;
            _heaters = new List<HeaterBase>();
            _dailyUsage = new List<DailyUsage>();
            this._month = month;
        }
        public void AddHeater(HeaterBase heater)
        {
            _heaters.Add(heater);
        }
        public void AddDailyUsage(DailyUsage dailyUsage) => _dailyUsage.Add(dailyUsage);
        public int GetDaysInMonth()
        {
            switch (_month)
            {
                case MonthEnum.january:
                case MonthEnum.march:
                case MonthEnum.may:
                case MonthEnum.july:
                case MonthEnum.august:
                case MonthEnum.october:
                case MonthEnum.december:
                    return 31;
                case MonthEnum.april:
                case MonthEnum.june:
                case MonthEnum.september:
                case MonthEnum.november:
                    return 30;
                case MonthEnum.february:
                    return 28;
                default:
                    return 0;
            }
        }

    }
}
