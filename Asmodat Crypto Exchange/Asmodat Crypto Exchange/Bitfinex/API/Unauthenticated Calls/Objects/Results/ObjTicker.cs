using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Types;

using System.Web;
using Newtonsoft.Json;

namespace Asmodat.BitfinexV1.API
{
    public class ObjTicker
    {
        /// <summary>
        /// (bid + ask) / 2
        /// </summary>
        public decimal mid { get; set; }
        /// <summary>
        /// Innermost bid.
        /// </summary>
        public decimal bid { get; set; }
        /// <summary>
        /// Innermost ask.
        /// </summary>
        public decimal ask { get; set; }
        /// <summary>
        /// The price at which the last order executed.
        /// </summary>
        public decimal last_price { get; set; }
        /// <summary>
        /// Lowest trade price of the last 24 hours
        /// </summary>
        public decimal low { get; set; }
        /// <summary>
        /// Highest trade price of the last 24 hours
        /// </summary>
        public decimal high { get; set; }
        /// <summary>
        /// Trading volume of the last 24 hours
        /// </summary>
        public decimal volume { get; set; }
        /// <summary>
        /// The timestamp at which this information was valid. - it is very likely its UnixTimeStamp
        /// </summary>
        public double timestamp { get; set; }

        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
