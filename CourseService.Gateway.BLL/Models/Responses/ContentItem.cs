namespace CourseService.Gateway.BLL.Models.Responses;

public class ContentItem
{
    public Guid ContentItemId { get; set; }
    public Guid LessonId { get; set; }
    public string ContentText { get; set; } = string.Empty; 
    public string ImageUrl { get; set; } = string.Empty; 
    public int Order { get; set; }
    public Lesson Lesson { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EditDate { get; set; }
    public bool IsDeleted { get; set; }
}