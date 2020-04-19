using DickinsonBros.AccountAPI.Infrastructure.BusService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Infrastructure.BusService
{
    public class BusService : IBusService
    {
        private readonly IBusHandlerService _busHandlerService;
        public BusService(IBusHandlerService busHandlerService)
        {
            _busHandlerService = busHandlerService;
        }
        public async Task SignalBusOutDBUpdatedAsync()
        {

        }

        public async Task RetriveSignalBusOutDBUpdatedAsync()
        {
            var items = await PullItemsAsync();

            while (items.Count > 0)
            {
                var results = await _busHandlerService.ProcessItems(null);

                foreach (var result in results)
                {
                    await UpdateItemResultAsync(result);
                }

                items = await PullItemsAsync();
            }
        }

        public async Task<List<BusItem>> PullItemsAsync()
        {
            await Task.CompletedTask;
            return new List<BusItem>();
        }

        public async Task UpdateItemResultAsync(BusItemResult busItemResult)
        {
            await Task.CompletedTask;
        }
    }

}
