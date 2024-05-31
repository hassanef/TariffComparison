using TariffComparison.Domain.Models;

namespace TariffComparison.Test.UnitTests
{
    public class PackagedTariffTests
    {
        [Theory]
        [InlineData(0, 800)] 
        [InlineData(3500, 800)] 
        [InlineData(4000, 800)] 
        [InlineData(4500, 950)] 
        [InlineData(10000, 2600)] 
        public void Calculate_AnnualCost_With_Various_Consumption_Has_Expected_Cost(int annualConsumption, decimal expectedCost)
        {
            var tariff = CreatePackagedTariff();

            var annualCost = tariff.CalculateAnnualCost(annualConsumption);

            Assert.Equal(expectedCost, annualCost);
        }
        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        public void When_Consumption_Is_Negative_Then_Calculate_AnnualCost_Throws_Argument_OutOfRange_Exception(int annualConsumption)
        {
            var tariff = CreatePackagedTariff();

            Assert.Throws<ArgumentOutOfRangeException>(() => tariff.CalculateAnnualCost(annualConsumption));
        }
        private static PackagedTariff CreatePackagedTariff()
        {
            return new PackagedTariff
            {
                IncludedKwh = new EnergyConsumption(4000),
                BaseCost = new Cost(800m),
                AdditionalKwhCost = new Cost(30m)
            };
        }
    }
}


