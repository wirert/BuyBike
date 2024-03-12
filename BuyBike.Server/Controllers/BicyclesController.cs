namespace BuyBike.Api.Controllers
{
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Bicycles controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {
        private readonly IBicyclesService bicyclesService;

        public BicyclesController(IBicyclesService _bicyclesService)
        {
            bicyclesService = _bicyclesService;
        }

        /// <summary>
        /// Get Bicycles from Db
        /// </summary>
        /// <param name="type">Bicycles type (optional)</param>
        /// <returns>Collection of Bicycle DTO</returns>
        [HttpGet]
        [Route("Get")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] string? type = null)
        {
            BikeType? bikeType = null;

            if (type != null)
            {
                bool isBikeType = Enum.TryParse<BikeType>(type, out var result);

                if (!isBikeType)
                {
                    return BadRequest("Invalid bicycle type.");                    
                }

                bikeType = result;
            }

            try
            {
                var bicycles = await bicyclesService.GetAllModelsAsync(bikeType);

                return Ok(bicycles);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
