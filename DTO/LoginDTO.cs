using System.ComponentModel.DataAnnotations;

namespace DTO;

public class LoginDto
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}