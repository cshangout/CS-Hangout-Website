using System.ComponentModel.DataAnnotations;

namespace Common.Models.DTOs;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}