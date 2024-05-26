namespace CourseService.Gateway.BLL.Models.Requests;

public class UpdateLessonCommand
{
    public Guid LessonId { get; set; }
    public string Title { get; set; }
    public bool IsDelete { get; set; }
}