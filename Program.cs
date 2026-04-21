<<<<<<< HEAD
﻿using IceCity.Enums;
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
=======
﻿using System.Diagnostics.Metrics;

namespace IceCity
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("----------------- Welcome To IceCity -----------------");
            Console.Write("Please Enter Your Name: ");
            var name = Console.ReadLine();
            Console.Write("Please Enter Your Id Name: ");
            var idName = int.Parse(Console.ReadLine());
            Owner owner1 = new Owner(name, idName);
            Console.Write("Please Enter Id House: ");
            var idHouse = int.Parse(Console.ReadLine());
            Console.Write("please Enter Adress: ");
            var address = Console.ReadLine();
            Console.Write("Please Enter Month: ");
            var month =Console.ReadLine().ToLower();
            if (!Enum.TryParse<MonthEnum>(month, true, out var monthEnum))
            {
                Console.WriteLine("Invalid month!");
                return;
            }
            Console.Clear();

            House house1 = new House(idHouse, address, owner1 ,monthEnum);
            owner1.AddHouse(house1);
            house1.AddHeater(new GasHeater(1500));
            house1.AddHeater(new ElectricHeater(1200));
            await WeatherService.FetchAndSaveLastMonthWeatherAsync(house1);
            int daysInMonth = DateTime.DaysInMonth(2026, (int)monthEnum);
            Random rnd = new Random();
            for (int i = 1; i <= daysInMonth; i++)
            {
                double hours = rnd.Next(1, 10);        
                double heater = rnd.Next(30, 70);      
                house1.AddDailyUsage(new DailyUsage(new DateTime(2026, (int)monthEnum, i), hours, heater));
            }
            foreach (var heater1 in house1.Heaters)
            {
                try 
                {
                    if (heater1 is GasHeater gas)
                    {
                        gas.TurnOn();
                    }
                    else if (heater1 is ElectricHeater electric)
                    {
                        electric.TurnOn();
                    }
                }catch (HeaterFailedException ex)
                {
                    int index = -1;
                    for (int i = 0; i < house1.Heaters.Count; i++)
                    {
                        if (house1.Heaters[i] == heater1)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index != -1)
                    {
                        Console.WriteLine($"Heater failed: {ex.Message}. Replacing heater...");
                        house1.ReplaceHeater(index, null);
                    }
                }
                
            }
            await TaskPrinter.PrintLastMonthDailyUsageWithTasks(house1);
            Report report = new Report();
            report.GenerateReport(owner1); 




        }

    }
}
>>>>>>> a1f5756017ebc787d6c800d1a50155861c004b18
