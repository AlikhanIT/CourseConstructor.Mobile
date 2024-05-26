using CourseService.Gateway.BLL.Interfaces.Services;
using CourseService.Gateway.BLL.Models.Requests;
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
    public Task<Course> UpdateCourse(UpdateCourseToUserCommand req) => _courseClient.UpdateCourse(req);
    public Task<Lesson> AddLesson(AddLessonToCourseCommand req) => _courseClient.AddLesson(req);
    public Task<Lesson> UpdateLesson(UpdateLessonCommand req) => _courseClient.UpdateLesson(req);
    public Task<List<ContentItem>> GetAllContentItems(Guid lessonId) => _courseClient.GetAllContentItems(lessonId);
    public Task<ContentItem> AddContentToLesson(AddContentToLessonCommand req) => _courseClient.AddContentToLesson(req);
    public Task<List<Lesson>> GetAllLessons(Guid id) => _courseClient.GetAllLessons(id);
    public Task<ContentItem> UpdateContentItem(UpdateContentItemCommand req) => _courseClient.UpdateContentItem(req);
}