using Microsoft.EntityFrameworkCore;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Data;

public interface IDataContext : IDisposable
{
    DbSet<User> Users { get; set; }
}