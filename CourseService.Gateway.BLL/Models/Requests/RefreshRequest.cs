namespace CourseService.Gateway.BLL.Models.Requests;

public class RefreshRequest
{
    public Guid UserId { get; set; }
    public string RefreshToken { get; set; }
}