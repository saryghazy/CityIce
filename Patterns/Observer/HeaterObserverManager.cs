using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Observer
{
    public class HeaterObserverManager
    {
        private readonly IObservableHeater _heater;
        private readonly IObserver _logger;
        public HeaterObserverManager(IObservableHeater heater, IObserver logger)
        {
            _heater = heater;
            _logger = logger;
        }
        public void StartMonitoring()
        {
            if (_heater == null || _logger == null)
                throw new InvalidOperationException();
            _heater.Attach(_logger);
            Console.WriteLine("Started monitoring the heater.");
        }
        public void StopMonitoring()
        {
            _heater.Detach(_logger);
            Console.WriteLine("Stopped monitoring the heater.");
        }

        
    }
}
