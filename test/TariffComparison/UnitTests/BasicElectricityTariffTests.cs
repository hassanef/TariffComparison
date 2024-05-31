using TariffComparison.Domain.Models;

namespace TariffComparison.Test.UnitTests
{
    public class BasicElectricityTariffTests
    {
        [Theory]
        [InlineData(0, 60)]
        [InlineData(3500, 830)] 
        [InlineData(4500, 1050)] 
        [InlineData(1000000, 220060)] 
        public void Calculate_AnnualCost_With_Various_Consumption_Has_Expected_Cost(int annualConsumption, decimal expectedCost)
        {
            var tariff = new BasicElectricityTariff
            {
                BaseCost = new Cost(5m),
                AdditionalKwhCost = new Cost(22m)
            };

            var annualCost = tariff.CalculateAnnualCost(annualConsumption);

            Assert.Equal(expectedCost, annualCost);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        public void Calculate_AnnualCost_With_Negative_Consumption_Throws_Argument_OutOfRange_Exception(int annualConsumption)
        {
            var tariff = new BasicElectricityTariff
            {
                BaseCost = new Cost(5m),
                AdditionalKwhCost = new Cost(22m)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => tariff.CalculateAnnualCost(annualConsumption));
        }

        [Theory]
        [InlineData(0, 3500, 770)] 
        [InlineData(5, 0, 60)] 
        public void Calculate_AnnualCost_With_Edge_Cases_Has_Expected_Cost(decimal baseCost, int annualConsumption, decimal expectedCost)
        {
            var tariff = new BasicElectricityTariff
            {
                BaseCost = new Cost(baseCost),
                AdditionalKwhCost = new Cost(22m)
            };

            var annualCost = tariff.CalculateAnnualCost(annualConsumption);

            Assert.Equal(expectedCost, annualCost);
        }
    }
}
