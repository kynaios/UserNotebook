using Microsoft.EntityFrameworkCore;
using UserNotebook.Models;

namespace UserNotebook.Context;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Adult> Adults { get; set; }
    public DbSet<Kid> Kids { get; set; }
    public DbSet<Report> Reports { get; set; }

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