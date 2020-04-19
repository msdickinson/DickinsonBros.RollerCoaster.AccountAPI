using System.Diagnostics.CodeAnalysis;

namespace DickinsonBros.AccountAPI.Infrastructure.OutDB.Models
{
    [ExcludeFromCodeCoverage]
    public class InsertItemRequest
    {
        public string EventName { get; set; }
        public object Payload { get; set; }
    }
}
