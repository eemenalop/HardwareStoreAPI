using billingSystem.Models;
using billingSystem.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace billingSystem.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //Get All Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        //Get User by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(user);
        }

        // Create new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Users newUser)
        {
            try
            {
                var user = await _userService.CreateUser(newUser);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Update user by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users updatedUser)
        {
            var user = await _userService.UpdateUser(id, updatedUser);
            if (user == null)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(user);
        }

        // Delete User by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}