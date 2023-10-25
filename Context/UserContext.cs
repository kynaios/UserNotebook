using Microsoft.EntityFrameworkCore;
using Npgsql;
using UserNotebook.Models;
using UserNotebook.Types;

namespace UserNotebook.Context;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Adult> Adults { get; set; }
    public DbSet<Kid> Kids { get; set; }
    public DbSet<Report> Reports { get; set; }
    
    public UserContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Sex)
            .HasConversion<int>();
        
        modelBuilder.Entity<Report>()
            .HasNoKey().ToView("reports");
    }
}