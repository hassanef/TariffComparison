namespace TariffComparison.Domain.Models
{
    public class PackagedTariff : TariffProduct
    {
        public EnergyConsumption IncludedKwh { get; init; }
        public required Cost BaseCost { get; init; }
        public required Cost AdditionalKwhCost { get; init; }

        public override decimal CalculateAnnualCost(int annualConsumption)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(annualConsumption);

            if (annualConsumption <= IncludedKwh.Value)
            {
                return BaseCost.Value;
            }
            else
            {
                var additionalConsumption = annualConsumption - IncludedKwh.Value;
                var additionalCost = additionalConsumption * AdditionalKwhCost.Value / 100;
                return BaseCost.Value + additionalCost;
            }
        }
    }

}
