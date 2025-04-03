using ColorsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColorsApi.Database.Configurations;

public class ColorEntityConfiguration : IEntityTypeConfiguration<ColorEntity>
{
    public void Configure(EntityTypeBuilder<ColorEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.ColorPaletteEntityId).IsRequired();
        builder.Property(c => c.Type).IsRequired();
        builder.Property(c => c.Red).IsRequired();
        builder.Property(c => c.Green).IsRequired();
        builder.Property(c => c.Blue).IsRequired();
    }
}
