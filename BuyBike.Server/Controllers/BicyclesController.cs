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
                bool isBikeType = Enum.TryParse(type, ignoreCase: true, out BikeType result);

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
        
        /// <summary>
        /// Fetch sorted and paged bicycles
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="itemsPerPage">Bicycles per page</param>
        /// <param name="orderBy">Order by string</param>
        /// <param name="desc">Is descending order</param>
        /// <param name="type">Bicycles type</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPaged")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPaged([FromQuery] int page,[FromQuery] int itemsPerPage, [FromQuery] string orderBy,[FromQuery] bool desc, [FromQuery] string? type = null)
        {
            BikeType? bikeType = null;

            if (type != null)
            {
                bool isBikeType = Enum.TryParse(type, ignoreCase: true, out BikeType result);

                if (!isBikeType)
                {
                    return BadRequest("Invalid bicycle type.");
                }

                bikeType = result;
            }

            try
            {
                var pagedBicycles = await bicyclesService.GetPagedModelsAsync(page, itemsPerPage, orderBy, desc, bikeType);

                return Ok(pagedBicycles);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
