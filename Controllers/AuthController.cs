using billingSystem.Dtos.LoginDtos;
using billingSystem.Dtos;
using billingSystem.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace billingSystem.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginDto loginDto)
        {
            try
            {
                var (user, token) = await _userService.Register(loginDto.Username, loginDto.Password);
                return Ok(new { user, token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}