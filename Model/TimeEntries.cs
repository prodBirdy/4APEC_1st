namespace Model;

public class TimeEntries
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan Duration { get; set; }
    
    public Guid UserId { get; set; } 
    
    // Navigation property
    public User User { get; set; } = null!; 
    public TaskEntries TaskEntries { get; set; } = null!;
}