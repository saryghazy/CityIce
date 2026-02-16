namespace IceCity
{
    internal abstract class HeaterBase
    {
        private double _powerValue;
        public double PowerValue { get; private set;  }
        protected HeaterBase( double powerValues)
        {
            this._powerValue = powerValues;
            this.PowerValue = powerValues;
        }
        public abstract double CalculateEffectivePower();
    }
}