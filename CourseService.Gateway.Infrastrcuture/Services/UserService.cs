using CourseService.Gateway.BLL.Interfaces.Services;
using CourseService.Gateway.BLL.Models.Responses;

namespace CourseService.Gateway.Infrastrcuture.Services;

public class UserService : IUserService
{
    private readonly IUserClient _userClient;

    public UserService(IUserClient userClient)
    {
        _userClient = userClient;
    }

    public async Task<JwtToken> RegisterUser(string username, string password)
    {
        return await _userClient.RegisterUser(username, password);
    }

    public async Task<JwtToken> AuthenticateUser(string username, string password)
    {
        return await _userClient.AuthenticateUser(username, password);
    }

    public async Task<JwtToken> RefreshUser(Guid userId, string refreshToken)
    {
        return await _userClient.RefreshUser(userId, refreshToken);
    }
    public async Task<bool> ValidateUser(string accessToken)
    {
        return await _userClient.ValidateUser(accessToken);
    }
}