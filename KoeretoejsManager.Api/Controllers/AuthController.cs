using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Models.HelperModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace KoeretoejsManager.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserAuthService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _userService.ValidateUser(request.Username, request.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                accessToken = token,
                expiresIn = 900
            });
        }
    }
}
