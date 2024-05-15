namespace CourseService.Gateway.BLL.Models.Responses;

public class Course
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; } = 0;
    public decimal SaleCost { get; set; } = 0;
    public bool IsSale { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime EditDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}