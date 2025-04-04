using ColorsApi.Database;
using ColorsApi.DTO;
using ColorsApi.Entities;
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
            .Where(p => !p.IsArchived)
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

    [HttpPost]
    public async Task<ActionResult<ColorPalette>> CreatePalette([FromBody] ColorPalette colorPalette)
    {
        if (colorPalette == null || colorPalette.Colors.Count != 4)
        {
            return BadRequest("La palette doit contenir 4 couleurs.");
        }

        try
        {
            var paletteEntity = new ColorPaletteEntity();

            var colorEntities = colorPalette.Colors.Select(c => new ColorEntity
            {
                Type = c.Type,
                Red = c.Red,
                Green = c.Green,
                Blue = c.Blue,
                ColorPaletteEntityId = paletteEntity.Id
            }).ToList();

            paletteEntity.Colors = colorEntities;

            dbContext.Palettes.Add(paletteEntity);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetColors),
                new { id = paletteEntity.Id },
                new
                {
                    paletteEntity.Id,
                    colorPalette.Colors
                });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ColorPalette>> DeletePalette(int id)
    {
        try
        {
            var palette = await dbContext.Palettes
                .Where(p => !p.IsArchived)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (palette == null)
            {
                return NotFound($"Palette avec Id = {id} non trouvée ou déjà archivée.");
            }

            palette.IsArchived = true;
            dbContext.Palettes.Update(palette);
            await dbContext.SaveChangesAsync();

            return NoContent();
        } 
        catch (Exception ex) 
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}
