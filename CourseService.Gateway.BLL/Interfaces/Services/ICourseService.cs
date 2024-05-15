using CourseService.Gateway.BLL.Models.Responses;

namespace CourseService.Gateway.BLL.Interfaces.Services;

public interface ICourseService
{
    Task<string> GetTestRoute();
    Task<IEnumerable<string>> ListCountries();
    Task ClearCache();
    Task CheckLanguageSupport();
    Task<Course> CreateCourse(string courseName);
    Task<IEnumerable<Course>> ListAllCourses();
    Task<CourseUser> AssignCourseToUser(Guid userId, Guid courseId);
    Task<IEnumerable<Course>> GetUserCourses(Guid userId);
    Task<Course> GetCourseDetails(Guid id);
}