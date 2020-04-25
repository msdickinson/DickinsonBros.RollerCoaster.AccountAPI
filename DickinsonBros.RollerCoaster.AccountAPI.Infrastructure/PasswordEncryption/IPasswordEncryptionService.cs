using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.PasswordEncryption.Models;

namespace DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.PasswordEncryption
{
    public interface IPasswordEncryptionService
    {
        EncryptResult Encrypt(string password, string salt = null);
    }
}