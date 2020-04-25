using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.JWT.Models
{
    [ExcludeFromCodeCoverage]
    public class JWTSettings
    {
        public string Secret { get; set; }
        public string RefreshSecret { get; set; }
    } 
}
