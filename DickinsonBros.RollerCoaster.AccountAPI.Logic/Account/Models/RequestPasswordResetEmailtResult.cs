namespace DickinsonBros.RollerCoaster.AccountAPII.Logic.Account.Models
{
    public enum RequestPasswordResetEmailResult
    {
        Successful,
        EmailNotFound,
        EmailNotActivated,
        NoEmailSentDueToEmailPreference
    }
}
