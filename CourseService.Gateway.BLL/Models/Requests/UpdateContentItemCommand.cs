namespace CourseService.Gateway.BLL.Models.Requests;

public class UpdateContentItemCommand
{
    public Guid ContentItemId { get; set; }
    public string ContentText { get; set; }
    public string ImageUrl { get; set; }
    public int Order { get; set; }
    public bool IsDeleted { get; set; }
}