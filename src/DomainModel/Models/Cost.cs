namespace TariffComparison.Domain.Models
{
    public record Cost
    {
        public decimal Value { get;}

        public Cost(decimal value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            Value = value;
        }

        public override string ToString() => $"{Value:C}";
    }
}

