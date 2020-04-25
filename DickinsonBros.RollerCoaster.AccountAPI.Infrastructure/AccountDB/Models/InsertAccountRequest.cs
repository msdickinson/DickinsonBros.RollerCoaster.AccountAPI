using DickinsonBros.RollerCoaster.AccountAPII.Abstractions;
using DickinsonBros.RollerCoaster.AccountAPII.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.AccountDB.Models
{
    [ExcludeFromCodeCoverage]
    public class InsertAccountRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string ActivateEmailToken { get; set; }
        public string EmailPreferenceToken { get; set; }
        public EmailPreference EmailPreference { get; set; }

    }
}
