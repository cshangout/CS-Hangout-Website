using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;

namespace Server.Infrastructure.Data;

public class DataContext : IdentityDbContext<IdentityUser>, IDataContext
{
    

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }

    public async Task SaveChanges()
    {
        try
        {
            SaveChangesAsync();
        }
        catch (Exception ex)
        {

        }
        
    }
}