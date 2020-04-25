//using DickinsonBros.DateTime;
//using DickinsonBros.DateTime.Abstractions;
//using DickinsonBros.DurableRest;
//using DickinsonBros.Logger;
//using DickinsonBros.Logger.Abstractions;
//using DickinsonBros.Redactor;
//using DickinsonBros.Redactor.Abstractions;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace DickinsonBros.RollerCoaster.AccountAPII.Proxy.Runner
//{
//    public class Startup
//    {
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddSingleton<IDateTimeService, DateTimeService>();
//            services.AddSingleton<IAccountProxy, AccountProxy>();
//            services.AddScoped<ICorrelationService, CorrelationService>();
//            services.AddScoped(typeof(ILoggingService<>), typeof(LoggingService<>));
//            services.AddLogging();
//            services.AddSingleton<IRedactorService, RedactorService>();
//            services.AddSingleton<IRestClientFactory, RestClientFactory>();
//            services.AddSingleton<IDurableRestService, DurableRestService>();
//        }
//    }
//}