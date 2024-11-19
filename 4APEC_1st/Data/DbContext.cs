using Microsoft.EntityFrameworkCore;
using Model;

namespace APEC_INF.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskEntries> Tasks { get; set; }
        public DbSet<TimeEntries> Times { get; set; }
    }
}