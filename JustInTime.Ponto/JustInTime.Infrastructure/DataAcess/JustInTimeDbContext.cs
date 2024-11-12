using Microsoft.EntityFrameworkCore;

namespace JustInTime.Ponto.JustInTime.Infrastructure.DataAcess;

public class JustInTimeDbContext : DbContext
{
    public JustInTimeDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Domain.Entities.Ponto> Ponto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JustInTimeDbContext).Assembly);
    }
}
