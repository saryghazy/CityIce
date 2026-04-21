using IceCity.Enums;
using IceCity.Factories;
using IceCity.Heaters;
using IceCity.Helpers;
using IceCity.Interfaces;
using IceCity.Models;
using IceCity.Patterns.Command;
using IceCity.Patterns.Facade;
using IceCity.Patterns.Observer;
using IceCity.Reports;
using IceCity.Services;

namespace IceCity
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("-------------- Welcome To IceCity --------------");

            
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter your ID: ");
            var id = int.Parse(Console.ReadLine());

            Owner owner = new Owner(name, id);

            Console.Write("Enter House ID: ");
            var houseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Address: ");
            var address = Console.ReadLine();

            Console.Write("Enter Month: ");
            var monthInput = Console.ReadLine();

            if (!Enum.TryParse<MonthEnum>(monthInput, true, out var month))
            {
                Console.WriteLine("Invalid month!");
                return;
            }

            Console.Clear();

            
            House house = new House(houseId, address, owner, month);
            owner.AddHouse(house);

            house.AddHeater(new GasHeater(1500));
            house.AddHeater(new ElectricHeater(1200));
            house.AddHeater(new SolarHeater(800));

            
            await WeatherServiceProxy.FetchAndSaveLastMonthWeatherAsync(house);

            
            Random rnd = new Random();
            int days = DateTime.DaysInMonth(2026, (int)month);

            for (int i = 1; i <= days; i++)
            {
                house.AddDailyUsage(new DailyUsage(
                    new DateTime(2026, (int)month, i),
                    rnd.Next(1, 10),
                    rnd.Next(30, 70)
                ));
            }

            
            foreach (var heater in house.Heaters)
            {
                heater.Attach(new HeaterLogger());
            }

            
            var invoker = new CommandInvoker();

            foreach (var heater in house.Heaters)
            {
                try
                {
                    invoker.AddCommand(new StartHeaterCommand(heater));
                }
                catch (HeaterFailedException ex)
                {
                    Console.WriteLine($"Heater failed: {ex.Message}");
                }
            }

            invoker.ExecuteCommands();

            
            var mainHeater = house.Heaters.First();

            IThermostat thermostat = new Thermostat();
            ITemperatureSensor sensor = new TemperatureSensor();

            var system = new HeatingSystemFacade(mainHeater, thermostat, sensor);

            system.ControlHeating(25);

            
            await TaskPrinter.PrintLastMonthDailyUsageWithTasks(house);
            ICostStrategyFactory factory = new CostStrategyFactory();
            CostService costService = new CostService(factory);

            Report report = new Report(costService);
            report.GenerateReport(owner);

            Console.WriteLine("-------------- System Finished --------------");
        }
    }
}