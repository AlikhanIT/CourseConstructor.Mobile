namespace CourseService.Gateway.BLL.Models.Requests;

public class AddLessonToCourseCommand
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
}