namespace BuyBike.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using Newtonsoft.Json;

    /// <summary>
    /// API product controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Get products 
        /// </summary>
        /// <param name="productType">Product type</param>
        /// <param name="query">Query params model</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(string productType, [FromQuery] GetAllQueryModel query, [FromQuery] QueryFilterModel? filter = null)
        {
            try
            {
                var productPage = await productService.GetAllAsync(query, productType, filter);

                return Ok(productPage);
            }
            catch (FileNotFoundException fnfe)
            {
                return NotFound(fnfe.Message);
            }
            catch (ArgumentException ae)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id">Product identifier</param>
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
                var bicycle = await productService.GetById(id);

                return Ok(bicycle);
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
