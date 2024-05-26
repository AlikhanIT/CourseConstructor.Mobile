namespace CourseService.Gateway.BLL.Models.Requests;

public class UpdateCourseToUserCommand
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public decimal SaleCost { get; set; }
    public bool IsSale { get; set; }
    public string ImageUrl { get; set; }
    public bool IsDelete { get; set; }
}