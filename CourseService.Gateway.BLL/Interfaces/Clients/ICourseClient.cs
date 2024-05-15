using CourseService.Gateway.BLL.Models.Responses;

namespace CourseService.Gateway.BLL.Interfaces.Services;


public interface ICourseClient
{
    Task<string> TestRoute();
    Task<IEnumerable<string>> GetCountries();
    Task ClearCache();
    Task CheckLanguage();
    Task<Course> CreateCourse(string courseName);
    Task<IEnumerable<Course>> GetAllCourses();
    Task<CourseUser> AddCourseToUser(Guid userId, Guid courseId);
    Task<IEnumerable<Course>> GetCoursesByUser(Guid userId);
    Task<Course>GetCourseById(Guid id);
}

