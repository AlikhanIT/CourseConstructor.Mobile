using CourseService.Gateway.BLL.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CourseService.Gateway.Infrastrcuture;

public static class ServiceExtensions
{
    public static IServiceCollection AddScopedClients(this IServiceCollection services)
    {
        services.AddScoped<ICourseClient, CourseClient>();
        services.AddScoped<IUserClient, UserClient>();

        
        services.AddScoped<ICourseService, Services.CourseService>();
        services.AddScoped<IUserService, Services.UserService>();
        
        services.AddHttpClient();
        
        return services;
    }
}