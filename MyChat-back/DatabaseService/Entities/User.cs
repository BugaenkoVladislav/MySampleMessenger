using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Entities;
[Index("Username",IsUnique = true)]
public class User
{
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    public long LoginPasswordId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string AvatarUrl { get; set; }
    [Required]
    public bool IsAdmin { get; set; }
    
    [ForeignKey("LoginPasswordId")]
    public LoginPassword LoginPassword { get; set; }
}