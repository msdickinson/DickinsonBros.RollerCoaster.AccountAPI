using System;
using System.Collections.Generic;
using System.Text;

namespace DickinsonBros.AccountAPI.Infrastructure.BusService.Models
{

    public class BusItemResult
    {
        public string QueueId { get; set; }
        public string UserId { get; set; }
        public bool Successful { get; set; }
    }
}
