//using Microsoft.AspNetCore.SignalR.Client;

//namespace DickinsonBros.AccountAPI.View.SignalR
//{

//    public class Client : IClient
//    {
//        internal HubConnection _connection;

//        public Client()
//        {
//            string URL = "https://localhost:5011/BusHub";
          
//            _connection = new HubConnectionBuilder()
//                .WithUrl(URL)
//                .WithAutomaticReconnect()
//                .Build();

//            _connection.StartAsync().GetAwaiter().GetResult();
//        }

//        public void SubscriptionNotification() 
//        {
//            //Make AJAX Call To Bus Deqeue

//            //Determine What Logic Manager Method To Call

//            //Return Success, Failed With End Result (Return Do not Retry)

//        }


//    }
//}
