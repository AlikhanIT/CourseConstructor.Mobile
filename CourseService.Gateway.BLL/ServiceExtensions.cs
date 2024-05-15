using CourseService.Gateway.BLL.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureOptionsBll(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CourseServiceOptions>(configuration.GetSection(CourseServiceOptions.Name));
        services.Configure<UserServiceOptions>(configuration.GetSection(UserServiceOptions.Name));

        return services;
    }
}