using System.ComponentModel.DataAnnotations;

namespace Server.Entities;

public class LoginPassword
{
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}