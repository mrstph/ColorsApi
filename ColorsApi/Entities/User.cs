﻿using Microsoft.AspNetCore.Identity;

namespace ColorsApi.Entities;

public class User : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
