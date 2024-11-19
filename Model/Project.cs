namespace Model;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    

    
    public ProjectStatus Status { get; set; }
    
    // Navigation property
    public User Manager { get; set; }
    public ICollection<TaskEntries> Tasks { get; set; } = new List<TaskEntries>();
}