using IceCity.Enums;
using IceCity.Interfaces;
using IceCity.Models;
using IceCity.Services;
using System;

namespace IceCity.Reports
{
    internal class Report
    {
        private readonly CostService _costService;

        public Report(CostService costService)
        {
            _costService = costService;
        }

        public void GenerateReport(House house)
        {
            double cost = _costService.CalculateMonthlyAverageCost(
                house,
                StrategyType.Standard 
            );

            Console.WriteLine($"Name Owner: {house.Owner.Name}");
            Console.WriteLine($"Id Owner: {house.Owner.Id}");
            Console.WriteLine($"Id house: {house.Id}");
            Console.WriteLine($"Address: {house.Address}");

            Console.WriteLine("Heaters:");
            foreach (var heater in house.Heaters)
            {
                Console.WriteLine($"- Effective Power: {heater.CalculateEffectivePower()}");
            }

            Console.WriteLine($"Monthly Cost: {cost}");
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