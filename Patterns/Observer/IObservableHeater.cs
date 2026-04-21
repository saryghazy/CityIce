using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Observer
{
    public interface IObservableHeater
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }
}
