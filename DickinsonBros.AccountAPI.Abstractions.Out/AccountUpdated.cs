namespace DickinsonBros.AccountAPI.Abstractions.Out
{
    public class AccountUpdated
    {
        public int AccountId { get; set; }
        public EmailPreference EmailPreference { get; set; }
    }
}
