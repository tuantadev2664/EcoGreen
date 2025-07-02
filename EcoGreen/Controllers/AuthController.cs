using Application.Entities.DTOs.User;
using Application.Interface.IServices;
using Application.Request.User;
using Microsoft.AspNetCore.Mvc;

namespace EcoGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: /api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _authService.RegisterAsync(registerModel);
            if (response.isSuccess)
            {
                return Ok(response);
            }
            return StatusCode((int)response.StatusCode, response);
        }

        // POST: /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _authService.LoginAsync(loginRequest);
            if (response.isSuccess)
            {
                return Ok(response);
            }
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
