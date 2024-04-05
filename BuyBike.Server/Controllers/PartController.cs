namespace BuyBike.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using BuyBike.Core.Models.Bicycle;
    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Core.Constants;

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
        /// Get Parts 
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
                var pagedParts = await productService.GetAllAsync(query, AppConstants.ProductTypes.Parts);

                return Ok(pagedParts);
            }
            catch (FileNotFoundException fnfe)
            {
                return NotFound(fnfe.Message);
            }
            catch (ArgumentException ae)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get Part details by Id
        /// </summary>
        /// <param name="id">Bicycle identifier</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var part = await productService.GetById(id);

                return Ok(part);
            }
            catch (ArgumentException ae)
            {
                return StatusCode(StatusCodes.Status404NotFound, ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
