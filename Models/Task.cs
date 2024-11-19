public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; }
    
    // Foreign keys
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public int? TimeId { get; set; }
    
    // Navigation properties
    public User User { get; set; } = null!;
    public Project Project { get; set; } = null!;
    public Time? Time { get; set; }
} 