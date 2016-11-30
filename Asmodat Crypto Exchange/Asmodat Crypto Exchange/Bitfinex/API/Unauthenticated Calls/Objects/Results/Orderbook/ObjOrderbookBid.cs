using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Asmodat.Types;

using Asmodat.Abbreviate;

namespace Asmodat.BitfinexV1.API
{
    public class ObjOrderbookBid
    {
        
        public decimal price { get; set; }
        public decimal amount { get; set; }
        public double timestamp { get; set; }

        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
