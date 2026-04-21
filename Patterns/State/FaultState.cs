using IceCity.Heaters;

namespace IceCity.Patterns.State
{
    public class FaultState : IHeaterState
    {
        private readonly HeaterBase _heater;
        public FaultState(HeaterBase heater)
        {
            this._heater = heater;
        }

        public void TurnOn()
        {
            throw new InvalidOperationException("Cannot turn ON a faulty heater");
        }

        public void TurnOff()
        {
            throw new InvalidOperationException("Cannot turn OFF a faulty heater");
        }
    }
}