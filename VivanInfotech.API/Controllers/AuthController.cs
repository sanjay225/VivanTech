using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VivanInfotech.API.Data;
using VivanInfotech.API.Models;
using VivanInfotech.API.Services;

namespace VivanInfotech.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController: ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            await _service.RegisterAsync(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User login)
        {
            var token = await _service.LoginAsync(login.Email, login.PasswordHash);
            if (token == null) return Unauthorized();

            return Ok(new { token });
        }
    }
}
