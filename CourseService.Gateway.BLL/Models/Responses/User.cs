using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CourseService.Gateway.BLL.Models.Responses;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public string PasswordHash { get; set; } = string.Empty;
    [JsonIgnore]
    public string RefreshToken { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime RefreshTokenExpiry { get; set; }

    public User SetRefreshToken(string refreshToken)
    {
        RefreshToken = refreshToken;

        return this;
    }
}