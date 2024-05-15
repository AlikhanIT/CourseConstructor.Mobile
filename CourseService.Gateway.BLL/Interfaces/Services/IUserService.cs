using CourseService.Gateway.BLL.Models.Responses;

namespace CourseService.Gateway.BLL.Interfaces.Services;

public interface IUserService
{
    Task<JwtToken> RegisterUser(string username, string password);
    Task<JwtToken> AuthenticateUser(string username, string password);
    Task<JwtToken> RefreshUser(Guid userId, string refreshToken);
    Task<bool> ValidateUser(string accessToken);
}