namespace DickinsonBros.RollerCoaster.AccountAPII.Abstractions.Out
{
    public class InsertAccountRequest
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public EmailPreference EmailPreference { get; set; }
    }
}
