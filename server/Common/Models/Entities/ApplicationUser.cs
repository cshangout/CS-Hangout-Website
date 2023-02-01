using System.ComponentModel.DataAnnotations;
using Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Common.Models.Entities;

public class ApplicationUser : IdentityUser 
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}