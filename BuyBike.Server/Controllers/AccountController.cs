namespace BuyBike.Api.Controllers
{
    using BuyBike.Core.Models.Account;
    using BuyBike.Core.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;

        public AccountController(IUserService _userService)
        {
            userService = _userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginDto model, [FromQuery] string? returnUrl = null)
        {
            var user = await userService.Authenticate(model.Email, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }

            var tokenString = userService.GenerateJwt(user);

            return Ok( new {token = tokenString});
        }
    }
}
