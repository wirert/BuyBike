namespace BuyBike.Api.Controllers
{
    using BuyBike.Core.Models.Bicycle;
    using BuyBike.Core.Models;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using BuyBike.Core.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IProductService productService;

        public PartController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Get bicycles 
        /// </summary>
        /// <param name="query">Query params model</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedProductDto<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQueryModel query)
        {
            if (query.Category != null)
            {
                bool isBikeType = Enum.TryParse(query.Category, ignoreCase: true, out BikeType result);

                if (!isBikeType)
                {
                    return BadRequest("Invalid bicycle category.");
                }

                query.Category = result.ToString();
            }

            try
            {
                var pagedBicycles = await productService.GetAllAsync(query);

                return Ok(pagedBicycles);
            }
            catch (FileNotFoundException fnfe)
            {
                return NotFound(fnfe.Message);
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

        /// <summary>
        /// Get Bicycle details by Id
        /// </summary>
        /// <param name="id">Bicycle identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BicycleDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var bicycle = await productService.GetById(id);

                return Ok(bicycle);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
