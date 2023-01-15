using Server.Infrastructure.Entities;

namespace DefaultNamespace;

public class UserRoles : IEntity
{
    public int Id { get; set; }
    public string RoleName { get; set; }
}