using DickinsonBros.RollerCoaster.AccountAPII.Abstractions;
using System.Diagnostics.CodeAnalysis;
namespace DickinsonBros.RollerCoaster.AccountAPII.Contracts
{
    [ExcludeFromCodeCoverage]
    public class Account
    {
        public int AccountId { get; set; }
        public bool Locked { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public EmailPreference EmailPreference { get; set; }
        public System.Guid EmailPreferenceToken { get; set; }
        public bool EmailActivated { get; set; }
        public System.Guid ActivateEmailToken { get; set; }
    }
}
