using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.AccountAPI.Abstractions
{
    [ExcludeFromCodeCoverage]
    public class ActivateEmailRequest
    {
        [Required]
        [MinLength(1)]
        public string? Token { get; set; }
    }
}
