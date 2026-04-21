using IceCity.Heaters;
using IceCity.Interfaces;

public class ElectricHeater : HeaterBase, IHeater
{
    protected override double FailureChance => 0.1;

    public ElectricHeater(double powerValue) : base(powerValue)
    {
    }

    public override double CalculateEffectivePower()
    {
        return PowerValue * 1.1;
    }
}