using ColorsApi.DTO;
using ColorsApi.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ColorsApi.Controllers;

[ApiController]
[Route("api/colorpalettes")]
[Consumes("application/json")]
[Produces("application/json")]
public class ColorPaletteController : ControllerBase
{
    [HttpGet]
    public ActionResult GetColors()
    {
        ColorDto response = new()
        {
            Palettes = new List<ColorPalette>()
            {
                new ColorPalette()
                {
                    Colors = new List<ColorModel>()
                    {
                        new ColorModel() { Type = 0, Red = 180, Green = 50, Blue = 120 },
                        new ColorModel() { Type = 1, Red = 53, Green = 168, Blue = 178 },
                        new ColorModel() { Type = 2, Red = 232, Green = 56, Blue = 202 },
                        new ColorModel() { Type = 3, Red = 56, Green = 90, Blue = 76 },
                    }
                },
                new ColorPalette()
                {
                    Colors = new List<ColorModel>()
                    {
                        new ColorModel() { Type = 0, Red = 180, Green = 50, Blue = 120 },
                        new ColorModel() { Type = 1, Red = 53, Green = 168, Blue = 178 },
                        new ColorModel() { Type = 2, Red = 232, Green = 56, Blue = 202 },
                        new ColorModel() { Type = 3, Red = 56, Green = 90, Blue = 76 },
                    }
                },
            }
        };

        return Ok(response);
    }
}
