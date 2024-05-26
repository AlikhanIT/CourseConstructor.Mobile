using System.Text;
using CourseService.Gateway.BLL.Interfaces.Services;
using CourseService.Gateway.BLL.Models.Requests;
using CourseService.Gateway.BLL.Models.Responses;
using CourseService.Gateway.BLL.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

public class CourseClient : ICourseClient
{
    private readonly HttpClient _httpClient;
    private readonly CourseServiceOptions _options;

    public CourseClient(HttpClient httpClient, IOptions<CourseServiceOptions> options)
    {
        _httpClient = httpClient;
        if (Uri.TryCreate(options.Value.BaseUrl, UriKind.Absolute, out var uriResult))
            _httpClient.BaseAddress = uriResult;
        else
            throw new ArgumentException("Invalid URL in configuration", nameof(options.Value.BaseUrl));
        _options = options.Value;
    }

    private async Task<T> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode(); 
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            throw; 
        }
        catch (Exception e)
        {
            throw;
        }
    }


    private async Task<T> PostAsync<T>(string endpoint, HttpContent content = null)
    {
        try
        {
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode(); 
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException e)
        {
            throw;
        }
        catch (Exception e)
        {
            throw;
        }
    }
    public Task<string> TestRoute() => GetAsync<string>(_options.TestRouteEndpoint);
    public Task<IEnumerable<string>> GetCountries() => GetAsync<IEnumerable<string>>(_options.GetCountriesEndpoint);
    public Task ClearCache() => PostAsync<string>(_options.ClearCacheEndpoint);
    public Task CheckLanguage() => PostAsync<string>(_options.CheckLanguageEndpoint);
    public Task<Course> CreateCourse(string courseName) => PostAsync<Course>(_options.CreateCourseEndpoint.Replace("{courseName}", courseName));
    public Task<IEnumerable<Course>> GetAllCourses() => PostAsync<IEnumerable<Course>>(_options.GetAllCoursesEndpoint);
    public Task<CourseUser> AddCourseToUser(Guid userId, Guid courseId) => PostAsync<CourseUser>(_options.AddCourseToUserEndpoint.Replace("{userId}", userId.ToString()).Replace("{courseId}", courseId.ToString()));
    public Task<IEnumerable<Course>> GetCoursesByUser(Guid userId) => GetAsync<IEnumerable<Course>>(_options.GetCoursesByUserEndpoint.Replace("{userId}", userId.ToString()));
    public Task<Course> GetCourseById(Guid id) => GetAsync<Course>(_options.GetCourseByIdEndpoint.Replace("{id}", id.ToString()));
    
    public async Task<Course> UpdateCourse(UpdateCourseToUserCommand req)
    {
        var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

        return await PostAsync<Course>(_options.UpdateCourseEndpoint, content);
    }
    public async Task<Lesson> AddLesson(AddLessonToCourseCommand req)
    {
        var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

        return await PostAsync<Lesson>(_options.AddLessonEndpoint, content);
    }
    public async Task<Lesson> UpdateLesson(UpdateLessonCommand req)
    {
        var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

        return await PostAsync<Lesson>(_options.UpdateLessonEndpoint, content);
    }
    public Task<List<ContentItem>> GetAllContentItems(Guid lessonId) => GetAsync<List<ContentItem>>(_options.GetAllContentItemsEndpoint.Replace("{lessonId}", lessonId.ToString()));
    public async Task<ContentItem> AddContentToLesson(AddContentToLessonCommand req) 
    {
        var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

        return await PostAsync<ContentItem>(_options.AddContentToLessonEndpoint, content);
    }
    public Task<List<Lesson>> GetAllLessons(Guid id) => GetAsync<List<Lesson>>(_options.GetAllLessonsEndpoint.Replace("{courseId}", id.ToString()));
    public async Task<ContentItem> UpdateContentItem(UpdateContentItemCommand req)
    {
        var content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

        return await PostAsync<ContentItem>(_options.UpdateContentItemEndpoint, content);
    }
}
