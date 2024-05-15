namespace CourseService.Gateway.BLL.Options;

public class CourseServiceOptions
{
    public static string Name { get; set; } = nameof(CourseServiceOptions);
    public string BaseUrl { get; set; }
    public string TestRouteEndpoint { get; set; }
    public string GetCountriesEndpoint { get; set; }
    public string ClearCacheEndpoint { get; set; }
    public string CheckLanguageEndpoint { get; set; }
    public string CreateCourseEndpoint { get; set; }
    public string GetAllCoursesEndpoint { get; set; }
    public string AddCourseToUserEndpoint { get; set; }
    public string GetCoursesByUserEndpoint { get; set; }
    public string GetCourseByIdEndpoint { get; set; }
}
