using FluentValidation;

namespace ColorsApi.DTO;

public class ColorDto
{
    public int Type { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}

public class CreateColorDtoValidator : AbstractValidator<ColorDto>
{
    public CreateColorDtoValidator()
    {
        RuleFor(color => color.Red).InclusiveBetween(0, 255);
        RuleFor(color => color.Green).InclusiveBetween(0, 255);
        RuleFor(color => color.Blue).InclusiveBetween(0, 255);
    }
}
