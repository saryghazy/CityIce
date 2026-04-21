namespace IceCity.Patterns.Facade
{
    public interface IThermostat
    {
        double GetDesiredTemperature();
        void SetDesiredTemperature(double desiredTemperature);
    }
}