using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity.Patterns.State
{
    public interface IHeaterState
    {
        void TurnOn();
        void TurnOff();
        
    }
}
