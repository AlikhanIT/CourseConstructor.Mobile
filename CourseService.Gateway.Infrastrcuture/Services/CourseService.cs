using CourseService.Gateway.BLL.Interfaces.Services;
using CourseService.Gateway.BLL.Models.Responses;

namespace CourseService.Gateway.Infrastrcuture.Services;

public class CourseService : ICourseService
{
    private readonly ICourseClient _courseClient;

    public CourseService(ICourseClient courseClient)
    {
        _courseClient = courseClient;
    }

    public Task<string> GetTestRoute() => _courseClient.TestRoute();

    public Task<IEnumerable<string>> ListCountries() => _courseClient.GetCountries();

    public Task ClearCache() => _courseClient.ClearCache();

    public Task CheckLanguageSupport() => _courseClient.CheckLanguage();

    public Task<Course> CreateCourse(string courseName) => _courseClient.CreateCourse(courseName);

    public Task<IEnumerable<Course>> ListAllCourses() => _courseClient.GetAllCourses();

    public Task<CourseUser> AssignCourseToUser(Guid userId, Guid courseId) => _courseClient.AddCourseToUser(userId, courseId);

    public Task<IEnumerable<Course>> GetUserCourses(Guid userId) => _courseClient.GetCoursesByUser(userId);

    public Task<Course> GetCourseDetails(Guid id) => _courseClient.GetCourseById(id);
}