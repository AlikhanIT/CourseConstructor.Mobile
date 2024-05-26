﻿namespace CourseService.Gateway.BLL.Models.Responses;

public class Lesson
{
    public Guid LessonId { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; }
    public virtual ICollection<ContentItem> ContentItems { get; set; } = new List<ContentItem>();
    public DateTime CreatedDate { get; set; }
    public DateTime EditDate { get; set; }
    public bool IsDeleted { get; set; }
}
