namespace TariffComparison.Domain.Models
{
    public record TariffProductName
    {
        public string Value { get; }

        public TariffProductName(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            Value = value;
        }

        public override string ToString() => Value;
    }
}
