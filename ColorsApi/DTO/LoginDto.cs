﻿using FluentValidation;

namespace ColorsApi.DTO;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
