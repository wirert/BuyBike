namespace BuyBike.Api.Controllers
{
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

        [HttpGet]
        [Route("GetBicycles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery] string? type = null)
        {
            if (type != null && !Enum.TryParse<BikeType>(type, out var bikeType))
            {
                return BadRequest("Invalid bicycle type.");
            }


            return Ok();
        }
    }
}
