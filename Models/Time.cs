public class Time
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan Duration { get; set; }
    
    // Navigation property
    public Task Task { get; set; } = null!;
} 