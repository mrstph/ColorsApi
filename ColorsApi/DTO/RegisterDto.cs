using FluentValidation;

namespace ColorsApi.DTO;

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.")
            .Matches(@"[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"\d")
            .WithMessage("Password must contain at least one digit.")
            .Matches(@"[!@#$%^&*(),.?""{}|<>_\-+=/\\[\]';:`~]")
            .WithMessage("Password must contain at least one special character.");
    }
}
