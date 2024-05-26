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
            if(token is not null)
                return Ok(token);
            
            return BadRequest(token);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserCredentials credentials)
        {
            var token = await _userService.AuthenticateUser(credentials.Username, credentials.Password);
            
            if(token is not null)
                return Ok(token);
            
            return BadRequest(token);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshUser([FromBody] RefreshRequest refreshRequest)
        {
            var token = await _userService.RefreshUser(refreshRequest.UserId, refreshRequest.RefreshToken);
            if(token is not null)
                return Ok(token);
            
            return BadRequest(token);
        }
        [HttpGet("validate")]
        public async Task<IActionResult> ValidateUser(string accessToken)
        {
            var token = await _userService.ValidateUser(accessToken);
            if(token)
                return Ok(token);
            
            return BadRequest(token);
        }
        /// <summary>
        /// Получает информацию о пользователе, используя токен доступа.
        /// </summary>
        /// <param name="authorization">Токен доступа из заголовка 'Authorization'.</param>
        /// <returns>Результат действия с информацией о пользователе.</returns>
        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> GetUserInfo([FromHeader(Name = "Authorization")] string authorization)
        {
            var token = authorization.StartsWith("Bearer ") ? authorization.Substring(7) : authorization;

            var userInfo = await _userService.GetUserInfo(token);
            if(userInfo is not null)
                return Ok(userInfo);
            
            return BadRequest(userInfo);
        }
    }
}
