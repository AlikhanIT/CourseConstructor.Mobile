using CourseService.Gateway.BLL.Models.Requests;
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
    Task<Course> UpdateCourse(UpdateCourseToUserCommand req);
    Task<Lesson> AddLesson(AddLessonToCourseCommand req);
    Task<Lesson> UpdateLesson(UpdateLessonCommand req);
    Task<List<ContentItem>> GetAllContentItems(Guid lessonId);
    Task<ContentItem> AddContentToLesson(AddContentToLessonCommand req);
    Task<List<Lesson>> GetAllLessons(Guid id);
    Task<ContentItem> UpdateContentItem(UpdateContentItemCommand req);
}