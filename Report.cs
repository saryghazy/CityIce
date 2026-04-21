using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class Report
    {
        public void GenerateReport(House house)
        {
            Service1 service = new Service1();
            double totalWorkingHours = service.CalculateTotalWorkingHours(house);
            double medianHeaterValue = service.CalculateMedianHeaterValue(house);
            double monthlyAverageCost = service.CalculateMonthlyAverageCost(house);
            Console.WriteLine($"Name Owner:{house.Owner.Name}");
            Console.WriteLine($"Id Owner: {house.Owner.Id}");
            Console.WriteLine($"Id house: {house.Id}");
            Console.WriteLine($"Address: {house.Address}");
            Console.WriteLine("Heaters:");
            foreach (var heater in house.Heaters)
            {
                Console.WriteLine($"-Effective Power: {heater.CalculateEffectivePower()}");
            }
            Console.WriteLine($"Total Working Hours: {totalWorkingHours}");
            Console.WriteLine($"Median Heater Value: {medianHeaterValue}");
            Console.WriteLine($"Monthly Average Cost: {monthlyAverageCost}");
           
        }

        public void GenerateReport(Owner owner)
        {
            Console.WriteLine($"Report for Owner: {owner.Name}");
            foreach (var house in owner.Houses)
            {
                GenerateReport(house);
                Console.WriteLine("----------------------------");
            }
        }


    }
}
