using System;
using System.Collections.Generic;
using System.Text;

namespace DickinsonBros.AccountAPI.Infrastructure.BusService.Models
{
    public class Payload
    {
        public int ClassName { get; set; }
        public object Data { get; set; }
    }
}
