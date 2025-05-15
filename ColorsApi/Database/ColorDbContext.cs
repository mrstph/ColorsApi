using Microsoft.EntityFrameworkCore;
using ColorsApi.Entities;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ColorsApi.Database;

public class ColorDbContext : IdentityDbContext<User>
{
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ColorPaletteEntity> Palettes { get; set; }

    public ColorDbContext(DbContextOptions<ColorDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorDbContext).Assembly);
    }
}
