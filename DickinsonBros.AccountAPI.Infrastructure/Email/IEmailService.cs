using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Infrastructure.EmailSender
{
    public interface IEmailService
    {
        Task SendActivateEmailAsync(string email, string activateToken, string updateEmailSettingsToken, string username);

        Task SendPasswordResetEmailAsync(string email, string passwordResetToken, System.Guid EmailPreferenceToken);
    }
}