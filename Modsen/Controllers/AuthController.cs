using Microsoft.AspNetCore.Mvc;
using Modsen.BL.Interfaces;
using Modsen.BL.Models;

namespace Modsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login and get token
        /// </summary>
        /// <remarks>
        /// Use your username and password. Then in the token input field enter "Bearer *YourToken*"
        /// </remarks>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            try
            {
                return Ok(await _authService.LoginAsync(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <remarks>
        /// Passwords must have at least one non alphanumeric character, at least one digit ('0'-'9'), at least one uppercase ('A'-'Z')
        /// </remarks>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            try
            {
                return Ok(await _authService.RegisterAsync(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
