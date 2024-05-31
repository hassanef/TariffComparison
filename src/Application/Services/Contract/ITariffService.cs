using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffComparison.Application.Dto;

namespace TariffComparison.Application.Services.Contract
{
    public interface ITariffService
    {
        IEnumerable<TariffCompareDto> CompareTariffs(int annualConsumption);
    }
}
