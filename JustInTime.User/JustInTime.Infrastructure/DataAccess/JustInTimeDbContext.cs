using Microsoft.EntityFrameworkCore;

namespace JustInTime.User.JustInTime.Infrastructure.DataAccess;

public class JustInTimeDbContext : DbContext
{
    public JustInTimeDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Domain.Entities.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JustInTimeDbContext).Assembly);
    }
}
