﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.AccountAPI.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class RequestPasswordResetEmailRequest
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
