using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace GAS_LATIHAN_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUsers();

            if (users is null || users.Count is 0) return NotFound();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);

            if (user is null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RequestCreateUser user)
        {
            if (user is null) return BadRequest();

            var result = await _userService.CreateUser(user);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, RequestUpdateUser user)
        {
            if (user is null) return BadRequest();

            var result = await _userService.UpdateUser(id, user);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userService.DeleteUser(id);

            if (result is false) return NotFound();
            return Ok(result);
        }
    }
}
