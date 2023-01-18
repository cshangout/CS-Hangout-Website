using Common.Interfaces;

namespace Common.Models.Entities;

public class UserRoles : BaseEntity<int>
{
    public int Id { get; set; }
    public string RoleName { get; set; }
}