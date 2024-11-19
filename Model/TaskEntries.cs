namespace Model;

public class TaskEntries
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; }
    
    // Foreign keys
    public Guid UserId { get; set; }
    public int ProjectId { get; set; }
    
    // Navigation properties
    public User User { get; set; } = null!;
    public Project Project { get; set; } = null!;

}