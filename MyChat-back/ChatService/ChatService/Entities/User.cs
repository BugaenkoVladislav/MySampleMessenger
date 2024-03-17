using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities;
public class User
{
    public long Id { get; set; }
    public long LoginPasswordId { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string AvatarUrl { get; set; }
    public bool IsAdmin { get; set; }
    
}