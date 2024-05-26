using CourseService.Gateway.BLL.Models.Requests;
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
    Task<Course> UpdateCourse(UpdateCourseToUserCommand req);
    Task<Lesson> AddLesson(AddLessonToCourseCommand req);
    Task<Lesson> UpdateLesson(UpdateLessonCommand req);
    Task<List<ContentItem>> GetAllContentItems(Guid lessonId);
    Task<ContentItem> AddContentToLesson(AddContentToLessonCommand req);
    Task<List<Lesson>> GetAllLessons(Guid id);
    Task<ContentItem> UpdateContentItem(UpdateContentItemCommand req);
}

