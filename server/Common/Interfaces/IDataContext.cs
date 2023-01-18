using Common.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.Interfaces;

public interface IDataContext : IDisposable
{
    DbSet<ApplicationUser> Users { get; set; }
    public Task SaveChanges();
}