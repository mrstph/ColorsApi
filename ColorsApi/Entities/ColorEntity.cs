using System.ComponentModel.DataAnnotations;

namespace ColorsApi.Entities;

public class ColorEntity
{
    public int Id { get; set; }
    public int Type { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public int ColorPaletteEntityId { get; set; }
}
