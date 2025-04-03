using ColorsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorsApi.Database.Configurations;

public class ColorPaletteEntityConfiguration
{
    public void Configure(EntityTypeBuilder<ColorPaletteEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Colors)
            .WithOne()
            .HasForeignKey(c => c.ColorPaletteEntityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
