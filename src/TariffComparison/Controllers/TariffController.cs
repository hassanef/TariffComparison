using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using TariffComparison.Application.Dto;
using TariffComparison.Application.Services.Contract;
using TariffComparison.Domain.Extensions;

namespace TariffComparison.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TariffController(ITariffService tariffService) : ControllerBase
    {
        private readonly ITariffService _tariffService = tariffService;

        /// <summary>
        /// Gets compare tariffs by consumption.
        /// </summary>
        /// <param name="consumption">The consumption.</param>
        /// <returns>A list compare tariffs.</returns>
        [HttpGet("compare")]
        [ProducesResponseType(typeof(IEnumerable<TariffCompareDto>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CompareTariffs([FromQuery, Required] int consumption)
        {
            var results = _tariffService.CompareTariffs(consumption);
            if (results.IsNullOrEmpty())
                return NotFound();
            return Ok(results);
        }
    }
}