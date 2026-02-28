using System.Collections;
using System.ComponentModel;
using System.IO;

using System.Security.Principal;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace IceCity
{
    public class DaliyRecord
    {
        public int _day { get; set; }
        public int _value { get; set; }
        public int _workingHours { get; set; }
        

    }
    public class App
    {
        public string name { get; private set; }
        public MonthEnum month { get;  set; }
        public List<DaliyRecord> daliyRecords = new List<DaliyRecord>();
        
        public App(string Name, MonthEnum Month)
        {
            this.name = Name;
            this.month = Month;

        }

        public int GetDaysInMonth()
        {
            
            switch (month)
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
        public void InputDailyValues()
        {
            int days = GetDaysInMonth();
            for (int i = 1; i <= days; i++)
            {
                Console.Write($"Enter value for day {i}: ");
                int value = int.Parse(Console.ReadLine());
                Console.Write($"Enter working for day {i}: ");
                int workingHours = int.Parse(Console.ReadLine());
                if ( workingHours < 0 || workingHours > 24)
                {
                    Console.WriteLine("Invalid working hours. Please enter a value between 0 and 24.");
                    i--;
                    continue;

                }
                daliyRecords.Add(new DaliyRecord { _day = i, _value = value , _workingHours = workingHours});
            }
        }
        public int GetWorkingHours()
        {
            int totalWorkingHours = 0;
            foreach (var record in daliyRecords)
            {
                totalWorkingHours += record._workingHours;
            }
            return totalWorkingHours;
        }
        //public void PrintRecords()
        //{
        //    foreach (var record in daliyRecords)
        //    {
        //        Console.WriteLine($"{name} in {month} on day {record._day} used {record._value} to working {record._workingHours}");
        //    }
        //}
        public void SortRecordsByValue()
        {
            daliyRecords.Sort((x, y) => x._value.CompareTo(y._value));
        }
        public double GetMedianValue()
        {
            SortRecordsByValue();
            int count = daliyRecords.Count;
            
            if (count % 2 == 0)
            {
                return (daliyRecords[count / 2 - 1]._value + daliyRecords[count / 2]._value) / 2.0;
                ;
            }
            else
            {
                return daliyRecords[count / 2]._value;
                
            }
        }
        public  double GetAverageCost()
        {
            double medianValue = GetMedianValue();
            int totalWorkingHours = GetWorkingHours();
            double averageCost = medianValue * (totalWorkingHours/24 * GetDaysInMonth());
            return averageCost;
        }
    }
}
