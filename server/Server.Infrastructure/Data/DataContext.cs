using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Data;

public class DataContext : DbContext, IDataContext
{
    private static string server = "cs-hangout-dev.cda79ewj6kbz.us-east-1.rds.amazonaws.com";
    private static string db = "Users";
    private static string user = "cshangoutdev";
    private static string pass = "d3vStr0ngKey$";
    private static string port = "3306";
    
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions options) : base(options) { }
    public void SaveChanges()
    {
        this.SaveChangesAsync();
    }
}