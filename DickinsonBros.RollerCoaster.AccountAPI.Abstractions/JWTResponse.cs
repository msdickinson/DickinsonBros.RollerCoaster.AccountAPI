﻿
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class JWTResponse
    {
        public string? AccessToken { get; set; }
        public int AccessTokenExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
        public int RefreshTokenExpiresIn { get; set; }
        public string? TokenType { get; set; }
    }
}
