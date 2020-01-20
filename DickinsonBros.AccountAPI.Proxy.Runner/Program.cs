using DickinsonBros.AccountAPI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DickinsonBros.AccountAPI.Proxy.Runner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();
            new Startup().ConfigureServices(collection);
            var serviceProvider = collection.BuildServiceProvider();

            var accountProxy = serviceProvider.GetService<IAccountProxy>();
            var result = await accountProxy.CreateAsync("https://localhost:5001/",
                new CreateAccountRequest
            {
                Email = "",
                Password = "",
                Username = ""
            });

            //Console.WriteLine("Hello World!");
        }
    }
}
