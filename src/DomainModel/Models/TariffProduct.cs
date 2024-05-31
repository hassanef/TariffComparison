namespace TariffComparison.Domain.Models
{
    public abstract class TariffProduct
    {
        public TariffProductName Name { get; init; }
        public TariffType Type { get; init; }
        public abstract decimal CalculateAnnualCost(int annualConsumption);
    }
}
