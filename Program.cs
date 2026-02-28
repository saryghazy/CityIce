using System.Diagnostics.Metrics;

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
