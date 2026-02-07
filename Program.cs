namespace IceCity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------- Welcome To IceCity -----------------");
            Console.Write("Please Enter Your Name: ");
            var name = Console.ReadLine();
            Console.Write("Please Enter Month: ");
            var month =Console.ReadLine().ToLower();
            var monthEnum = (MonthEnum)Enum.Parse(typeof(MonthEnum), month, true);
            App app = new App(name, monthEnum);
            app.InputDailyValues();
            double x =(double)app.GetAverageCost();
            Console.WriteLine(x);

        }
        
    }
}
