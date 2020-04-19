using System;
using System.Collections.Generic;
using System.Text;

namespace DickinsonBros.AccountAPI.Infrastructure.BusService.Models
{
    public class BusItem
    {
        public int QueueId { get; set; }
        public int TopicId { get; set; }
        public Payload Payload { get; set; }
        public string CorrelationId { get; set; }
    }
}
