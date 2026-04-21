using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Observer
{
    public class HeaterLogger: IObserver
    {
        public void Update(string message)
        {
            Log(message);
        }

        private void Log(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] [Heater Logger] {message}"); ;
        }
    }
}
