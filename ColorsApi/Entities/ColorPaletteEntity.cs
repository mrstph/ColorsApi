using ColorsApi.Models;

namespace ColorsApi.Entities;

public class ColorPaletteEntity
{
    public int Id { get; set; }
    public List<ColorEntity> Colors { get; set; } = new();
    public bool IsArchived { get; set; }
}
