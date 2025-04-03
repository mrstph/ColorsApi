using Microsoft.EntityFrameworkCore;
using ColorsApi.Entities;
using Microsoft.VisualBasic;

namespace ColorsApi.Database;

public class ColorDbContext : DbContext
{
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ColorPaletteEntity> Palettes { get; set; }

    public ColorDbContext(DbContextOptions<ColorDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorDbContext).Assembly);
    }
}
