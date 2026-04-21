using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.Observer
{
    public interface IObserver
    {
        void Update(string message);
    }
}
