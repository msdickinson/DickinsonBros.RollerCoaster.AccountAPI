﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class LoginRequest
    {
        [Required]
        [MinLength(1)]
        public string? Username { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
