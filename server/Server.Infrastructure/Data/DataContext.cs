using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Data;

public class DataContext : DbContext, IDataContext
{
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions options) : base(options) { }
}