using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class UpdatePasswordRequest
    {
        [Required]
        [MinLength(8)]
        public string? ExistingPassword { get; set; }

        [Required]
        [MinLength(8)]
        public string? NewPassword { get; set; }
    }
}
