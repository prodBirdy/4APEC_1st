using System.ComponentModel.DataAnnotations;

namespace Model;

public class User
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; }
    
    public string Email { get; set; } = string.Empty;
    [Key]
    public Guid UserId { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    // Navigation property
    public ICollection<TaskEntries> Tasks { get; set; } = new List<TaskEntries>();
}