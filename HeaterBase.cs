using System.Runtime.InteropServices;

namespace IceCity
{
    internal abstract class HeaterBase
    {
        public event EventHandler<EventArgs> HeaterChanged;//
        public event EventHandler<EventArgs> OpenHeater;//
        public event EventHandler<HeaterDurationEventArgs> CloseHeater;//
        private static int _idCounter = 1;//
        public int Id { get; private set; }//
        private double _powerValue;
        public double PowerValue { get; private set; }
        protected abstract double FailureChance { get; }//
        private static readonly Random _random = new Random();//
        private DateTime? _lastOpenTime;//
        protected HeaterBase(double powerValues)
        {
            this.Id = _idCounter++;//
            this._powerValue = powerValues;
            this.PowerValue = powerValues;
        }
        public abstract double CalculateEffectivePower();
        protected void OnOpen()//
        {
            if (_random.NextDouble() < FailureChance)
                throw new HeaterFailedException($"{GetType().Name} failed!");

            _lastOpenTime = DateTime.UtcNow;
            OpenHeater?.Invoke(this, EventArgs.Empty);
        }
        protected void OnClose(DateTime date, double workingHours, double heaterValue)
        {
            if (_lastOpenTime.HasValue)
            {
                DateTime closeTime = DateTime.UtcNow;
                double hoursWorked = (closeTime - _lastOpenTime.Value).TotalHours;

                CloseHeater?.Invoke(this,
                    new HeaterDurationEventArgs(closeTime, hoursWorked, PowerValue));

                _lastOpenTime = null;
            }
        }
    }
}