using Microsoft.EntityFrameworkCore;
using Model;

namespace BL.Data;

public class BackendDbContext : DbContext
{
    private string _connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TimeTrack;User Id=sa;Password=YourStrongPassword123;TrustServerCertificate=true;");
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskEntries> Tasks { get; set; }
    public DbSet<TimeEntries> Times { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}