namespace TariffComparison.Domain.Models
{
    public class BasicElectricityTariff : TariffProduct
    {
        public required Cost BaseCost { get; init; }
        public required Cost AdditionalKwhCost { get; init; }

        public override decimal CalculateAnnualCost(int annualConsumption)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(annualConsumption);
            var baseCostPerYear = BaseCost.Value * 12;
            var consumptionCost = annualConsumption * AdditionalKwhCost.Value / 100;
            return baseCostPerYear + consumptionCost;
        }
    }
}
