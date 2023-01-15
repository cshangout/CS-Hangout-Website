using System.ComponentModel.DataAnnotations;

namespace Server.Infrastructure.Entities.Users;

public class User : IEntity
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Username is required")]
    [StringLength(40, MinimumLength = 5)]
    public string UserName { get; set; }
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}