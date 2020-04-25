using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Logic.Account.Models
{
    [ExcludeFromCodeCoverage]
    public class LoginDescriptor
    {
        public LoginResult Result { get; internal set; }
        public int? AccountId { get; internal set; }
    }
}
