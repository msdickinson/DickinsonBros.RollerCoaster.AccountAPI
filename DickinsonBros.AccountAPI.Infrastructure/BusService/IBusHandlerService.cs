using DickinsonBros.AccountAPI.Infrastructure.BusService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Infrastructure.BusService
{
    public interface IBusHandlerService
    {
        Task<List<BusItemResult>> ProcessItems(List<BusItem> busItems);
    }
}