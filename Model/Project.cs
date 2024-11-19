namespace Model;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public Guid ManagerId { get; set; }
    
    public ProjectStatus Status { get; set; }
    
    // Navigation property
    public ICollection<TaskEntries> Tasks { get; set; } = new List<TaskEntries>();
}