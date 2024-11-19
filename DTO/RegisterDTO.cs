using System.ComponentModel.DataAnnotations;

namespace DTO;

public class RegisterDTO
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    
}