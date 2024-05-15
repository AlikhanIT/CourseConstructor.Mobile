using System.Text;
using CourseService.Gateway.BLL.Interfaces.Services;
using CourseService.Gateway.BLL.Models.Requests;
using CourseService.Gateway.BLL.Models.Responses;
using CourseService.Gateway.BLL.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

public class UserClient : IUserClient
{
    private readonly HttpClient _httpClient;
    private readonly UserServiceOptions _options;

    public UserClient(HttpClient httpClient, IOptions<UserServiceOptions> options)
    {
        _httpClient = httpClient;
        if (Uri.TryCreate(options.Value.BaseUrl, UriKind.Absolute, out var uriResult))
            _httpClient.BaseAddress = uriResult;
        else
            throw new ArgumentException("Invalid URL in configuration", nameof(options.Value.BaseUrl));
        _options = options.Value;
    }

    private async Task<T> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode(); 
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            throw; 
        }
        catch (Exception e)
        {
            throw;
        }
    }


    private async Task<T> PostAsync<T>(string endpoint, HttpContent content = null)
    {
        try
        {
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode(); 
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            throw;
        }
        catch (Exception e)
        {
            throw;
        }
    }
    public Task Register() => PostAsync<string>(_options.RegisterEndpoint);
    public async Task<JwtToken> RegisterUser(string username, string password)
    {
        var registerDto = new RegisterDto { Username = username, Password = password };
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");

        return await PostAsync<JwtToken>(_options.RegisterEndpoint, content);
    }
    public async Task<JwtToken> AuthenticateUser(string username, string password)
    {
        var registerDto = new LoginDto() { Username = username, Password = password };
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");

        return await PostAsync<JwtToken>(_options.AuthenticateEndpoint, content);
    }
    public async Task<JwtToken> RefreshUser(Guid userId, string refreshToken)
    {
        var registerDto = new RefreshTokenDto() { UserId = userId, RefreshToken = refreshToken };
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");

        return await PostAsync<JwtToken>(_options.AuthenticateEndpoint, content);
    }
    public async Task<bool> ValidateUser(string accessToken)
    {
        return await GetAsync<bool>(_options.AuthenticateEndpoint.Replace("{accessToken}", accessToken));
    }
}
