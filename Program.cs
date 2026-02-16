namespace IceCity
{
    internal class Program
    {
        static void Main(string[] args)
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

            House house1 = new House(idHouse, address, owner1 ,monthEnum);
            owner1.AddHouse(house1);
            //house1.AddHeater(new GasHeater(50));
            //house1.AddHeater(new ElectricHeater(70));
            //house1.AddDailyUsage(new DailyUsage(new DateTime(2026, 1, 1), 5, 50));
            //house1.AddDailyUsage(new DailyUsage(new DateTime(2026, 1, 2), 6, 55));
            Console.Clear();
            int daysInMonth = DateTime.DaysInMonth(2026, (int)monthEnum);
            Random rnd = new Random();
            for (int i = 1; i <= daysInMonth; i++)
            {
                double hours = rnd.Next(1, 10);        
                double heater = rnd.Next(30, 70);      
                house1.AddDailyUsage(new DailyUsage(new DateTime(2026, (int)monthEnum, i), hours, heater));
            }

            Report report = new Report();
            report.GenerateReport(owner1); 




        }

    }
}
