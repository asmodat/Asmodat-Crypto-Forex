using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Asmodat.Types;

using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Objects;

namespace Asmodat.BitfinexV1.API
{
    public class ObjTrades
    {
        
        public int tid { get; set; }
        public double timestamp { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }

        public string exchange { get; set; }

        /// <summary>
        /// "sell" or "buy" (can be "" if undetermined)
        /// </summary>
        public string type { get; set; }


        


        [JsonIgnore]
        public bool IsTypeBuy
        {
            get
            {
                if (type.IsNullOrWhiteSpace())
                    return false;

                if (type.ToLower() == "buy")
                    return true;

                return false;
            }
        }

        [JsonIgnore]
        public bool IsTypeSell
        {
            get
            {
                if (type.IsNullOrWhiteSpace())
                    return false;

                if (type.ToLower() == "sell")
                    return true;

                return false;
            }
        }

        [JsonIgnore]
        public bool IsTypeUndetermined
        {
            get
            {
                if (type.IsNullOrWhiteSpace())
                    return false;

                if (type.ToLower() == "")
                    return true;

                return false;
            }
        }


        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
