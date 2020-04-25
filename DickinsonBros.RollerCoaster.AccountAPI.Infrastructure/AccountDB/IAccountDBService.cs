using System.Threading.Tasks;
using DickinsonBros.RollerCoaster.AccountAPII.Abstractions;
using DickinsonBros.RollerCoaster.AccountAPII.Contracts;
using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.AccountDB.Models;

namespace DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.AccountDB
{
    public interface IAccountDBService
    {
        Task<ActivateEmailWithTokenDBResult> ActivateEmailWithTokenAsync(string activateEmailToken);
        Task DisablePasswordResetTokenAsync(string passwordResetToken);
        Task<InsertAccountResult> InsertAccountAsync(InsertAccountRequest insertAccountRequest);
        Task InsertPasswordResetTokenAsync(int accountId, string PasswordResetToken);
        Task<Account> SelectAccountByAccountIdAsync(int accountId);
        Task<Account> SelectAccountByEmailAsync(string email);
        Task<Account> SelectAccountByUserNameAsync(string username);
        Task<int?> SelectAccountIdFromPasswordResetTokenAsync(string passwordResetToken);
        Task UpdateEmailPreferenceAsync(int accountId, EmailPreference emailPreference);
        Task<UpdateEmailPreferenceWithTokenDBResult> UpdateEmailPreferenceWithTokenAsync(string emailPreferenceToken, EmailPreference emailPreference);
        Task UpdatePasswordAsync(int accountId, string passwordHash, string salt);
        Task InsertPasswordAttemptFailedAsync(int accountId);
    }
}