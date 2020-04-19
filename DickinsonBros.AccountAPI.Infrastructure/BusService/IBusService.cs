using DickinsonBros.AccountAPI.Infrastructure.BusService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Infrastructure.BusService
{
    public interface IBusService
    {
        Task<List<BusItem>> PullItemsAsync();
        Task RetriveSignalBusOutDBUpdatedAsync();
        Task SignalBusOutDBUpdatedAsync();
        Task UpdateItemResultAsync(BusItemResult busItemResult);
    }
}