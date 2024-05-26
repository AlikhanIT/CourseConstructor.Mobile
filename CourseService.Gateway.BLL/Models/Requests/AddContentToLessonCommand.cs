namespace CourseService.Gateway.BLL.Models.Requests;

public class AddContentToLessonCommand
{
    public Guid LessonId { get; set; }
    public string ContentText { get; set; }
    public string ImageUrl { get; set; }
    public int Order { get; set; }
}