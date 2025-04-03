using ColorsApi.Database;
using ColorsApi.DTO;
using ColorsApi.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColorsApi.Controllers;

[ApiController]
[Route("api/colorpalettes")]
[Consumes("application/json")]
[Produces("application/json")]
public class ColorPaletteController(ColorDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetColors()
    {
        var palettes = await dbContext.Palettes
            .Include(p => p.Colors)
            .ToListAsync();

        ColorDto response = new()
        {
            Palettes = palettes.Select(p => new ColorPalette
            {
                Colors = p.Colors.Select(c => new ColorModel
                {
                    Type = c.Type,
                    Red = c.Red,
                    Green = c.Green,
                    Blue = c.Blue
                }).ToList()
            }).ToList()
        };

        return Ok(response);
    }
}
