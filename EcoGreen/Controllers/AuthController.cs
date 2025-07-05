using Application.Entities.Base;
using Application.Entities.DTOs.User;
using Application.Interface.IServices;
using AutoMapper;
using EcoGreen.Service;
using Microsoft.AspNetCore.Mvc;

namespace EcoGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        // POST: /api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterDTO registerModel, IFormFile? imageFile,
            [FromServices] CloudinaryService cloudinaryService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(registerModel);
            if (imageFile != null && imageFile.Length > 0)
            {
                // Upload the image to Cloudinary and get the URL
                var imageUrl = await cloudinaryService.UploadImageAsync(imageFile);
                user.ProfilePhotoUrl = imageUrl; // Assuming UserRegisterDTO has an ImageUrl property
            }
            else
            {
                user.ProfilePhotoUrl = "/Helpers/profile_base.jpg"; // Set to null if no image is provided
            }
            var response = await _authService.RegisterAsync(registerModel, user.ProfilePhotoUrl);
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
