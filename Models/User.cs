public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Navigation property
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
} 