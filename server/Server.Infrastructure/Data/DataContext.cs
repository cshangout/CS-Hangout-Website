using Common.Interfaces;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Server.Infrastructure.Data;

public class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
{
    public DbSet<ApplicationUser> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //     modelBuilder.
    // }
    

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