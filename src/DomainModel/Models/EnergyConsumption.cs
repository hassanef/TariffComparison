namespace TariffComparison.Domain.Models
{
    public readonly record struct EnergyConsumption
    {
        public int Value { get; }

        public EnergyConsumption(int value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            Value = value;
        }

        public override string ToString() => $"{Value} kWh";
    }
}
