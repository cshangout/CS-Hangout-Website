using System.ComponentModel.DataAnnotations;

namespace Server.Infrastructure.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    [Required]
    [StringLength(40, MinimumLength = 5)]
    public string UserName { get; set; }
    public string Password { get; set; }
    // [Required]
    // public byte[] PasswordHash { get; set; }
    // [Required]
    // public byte [] PasswordSalt { get; set; }
    // public DateTime CreatedDate { get; set; } = DateTime.Now;
    // public DateTime PasswordChangedLast { get; set; }
}