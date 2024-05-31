using TariffComparison.Application.Dto;
using TariffComparison.Application.Services.Contract;
using TariffComparison.Domain.Models;

namespace TariffComparison.Application.Services
{
    public class TariffService: ITariffService
    {
        private readonly List<TariffProduct> _products;

        public TariffService()
        {
            _products = new List<TariffProduct>
            {
                new BasicElectricityTariff
                {
                    Name = new TariffProductName("Product A"),
                    Type = TariffType.BasicElectricity,
                    BaseCost = new Cost(5),
                    AdditionalKwhCost = new Cost(22)
                },
                new PackagedTariff
                {
                    Name = new TariffProductName("Product B"),
                    Type =  TariffType.Packaged,
                    IncludedKwh = new EnergyConsumption(4000),
                    BaseCost = new Cost(800),
                    AdditionalKwhCost = new Cost(30)
                }
            };
        }
        //if this process change to a I/O bound process, then it should be change to Async method
        public IEnumerable<TariffCompareDto> CompareTariffs(int annualConsumption)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(annualConsumption);

            return  _products.Select(p => new TariffCompareDto
            (
                p.Name.Value, 
                p.CalculateAnnualCost(annualConsumption)
            )).OrderBy(result => result.AnnualCost)
              .AsEnumerable();
        }
    }
}
