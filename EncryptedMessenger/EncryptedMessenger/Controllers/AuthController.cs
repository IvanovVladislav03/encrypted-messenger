using EncryptedMessenger.Application.DTOs;
using EncryptedMessenger.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EncryptedMessenger.WebAPI.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _authService.Register(registerDto.Username, registerDto.Password, registerDto.PublicKey);

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authService.Login(loginDto.Username, loginDto.Password);

            var cookieOptions = new CookieOptions()
            {
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            };

            HttpContext.Response.Cookies.Append("cookies-token", token, cookieOptions);

            return Ok(token);
        }
    }
}
