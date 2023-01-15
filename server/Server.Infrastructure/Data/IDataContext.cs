using Microsoft.EntityFrameworkCore;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;

namespace Server.Infrastructure.Data;

public interface IDataContext : IDisposable
{
    DbSet<User> Users { get; set; }
    public Task SaveChanges();
}