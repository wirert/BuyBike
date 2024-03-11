namespace BuyBike.Api.Controllers
{
    using BuyBike.Core.Models.Account;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService userService;
        private UserManager<AppUser> userManager;

        public AccountController(IUserService _userService, 
            UserManager<AppUser> _userManager)
        {
            userService = _userService;
            userManager = _userManager;
        }

        /// <summary>
        /// Login to application
        /// </summary>
        /// <param name="model">Login credentials</param>
        /// <param name="returnUrl">Return URL</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            AppUser? user;

            try
            {
                user = await userService.Authenticate(model.Email, model.Password);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }

            var tokenString = userService.GenerateJwt(user);

            return Ok(new { token = tokenString });
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="model">User register form data</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new AppUser()
            {
                Email = WebUtility.HtmlEncode(model.Email),
                FirstName = WebUtility.HtmlEncode(model.FirstName),
                LastName = WebUtility.HtmlEncode(model.LastName),
                PhoneNumber = model.PhoneNumber,                
                UserName = WebUtility.HtmlEncode(model.Email)
            };

            try
            {
                var createdUser = await userManager.CreateAsync(user, model.Password);
                

                if (createdUser.Succeeded)
                {
                    var token = userService.GenerateJwt(user);

                    return Ok(new { token });
                }

                return StatusCode(StatusCodes.Status400BadRequest, createdUser.Errors);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
