namespace BuyBike.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using BuyBike.Core.Models;
    using BuyBike.Core.Models.Bicycle;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;
    using BuyBike.Core.Constants;

    /// <summary>
    /// Bicycles controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly IBicycleService bicyclesService;
        private readonly IProductService productService;

        public BicycleController(IBicycleService _bicyclesService, IProductService _productService)
        {
            bicyclesService = _bicyclesService;
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
            try
            {
                var pagedBicycles = await productService.GetAllAsync(query, AppConstants.ProductTypes.Bicycles);

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
                var bicycle = await bicyclesService.GetById(id);

                return Ok(bicycle);
            }
            catch(ArgumentException e)
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
