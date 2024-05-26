namespace CourseService.Gateway.BLL.Options;

public class UserServiceOptions
{
    public static string Name { get; set; } = nameof(UserServiceOptions);
    public string BaseUrl { get; set; }
    public string RegisterEndpoint { get; set; }
    public string AuthenticateEndpoint { get; set; }
    public string RefreshEndpoint { get; set; }
    public string ValidateEndpoint { get; set; }
    public string GetInfoEndpoint { get; set; }
}
