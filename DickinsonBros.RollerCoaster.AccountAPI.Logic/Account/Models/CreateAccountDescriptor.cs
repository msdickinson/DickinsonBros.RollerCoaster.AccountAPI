using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.RollerCoaster.AccountAPII.Logic.Account.Models
{
    [ExcludeFromCodeCoverage]
    public class CreateAccountDescriptor
    {
        public CreateAccountResult Result { get; set; }
        public int? AccountId { get; set; }
    }
}
