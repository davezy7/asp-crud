using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Services.PasswordService;
using GAS_LATIHAN_ASP.Services.TokenService;
using GAS_LATIHAN_ASP.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace GAS_LATIHAN_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(
            IPasswordService passwordService, 
            IUserService userService,
            ITokenService tokenService
        ) {
            _passwordService = passwordService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(RequestLoginUser userData)
        {
            if (userData == null) return BadRequest();

            var existingUser = await _userService.GetUserByEmail(userData.Email);
            if (existingUser == null) return BadRequest(); // User doesn't exist

            var checkPassword = await _passwordService.CheckPassword(existingUser.ID, userData.Password);
            if (!checkPassword) return BadRequest(); // Wrong Password

            var token = _tokenService.GenerateUserToken(existingUser.ID, existingUser.Email);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RequestCreateUser userData)
        {
            if (userData == null) return BadRequest();

            var userExists = await _userService.CheckExistingUserByEmail(userData.Email);
            if (userExists) return BadRequest();

            var encryptedPassword = _passwordService.Hash(userData.Password);
            userData.Password = encryptedPassword;

            var result = await _userService.CreateUser(userData);
            return Ok(result);
        }
    }
}
