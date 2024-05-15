namespace CourseService.Gateway.BLL.Models.Responses;

public class CourseUser
{
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EditDate { get; set; }
    public bool IsDeleted { get; set; }
}