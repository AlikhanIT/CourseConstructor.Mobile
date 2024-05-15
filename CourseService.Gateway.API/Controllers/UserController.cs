using Microsoft.AspNetCore.Mvc;
using CourseService.Gateway.BLL.Interfaces.Services;
using CourseService.Gateway.BLL.Models.Requests;

namespace CourseService.Gateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserCredentials credentials)
        {
            var token = await _userService.RegisterUser(credentials.Username, credentials.Password);
            return Ok(token);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserCredentials credentials)
        {
            var token = await _userService.AuthenticateUser(credentials.Username, credentials.Password);
            return Ok(token);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshUser([FromBody] RefreshRequest refreshRequest)
        {
            var token = await _userService.RefreshUser(refreshRequest.UserId, refreshRequest.RefreshToken);
            return Ok(token);
        }
        [HttpGet("refresh")]
        public async Task<IActionResult> ValidateUser(string accessToken)
        {
            var token = await _userService.ValidateUser(accessToken);
            return Ok(token);
        }
    }
}
