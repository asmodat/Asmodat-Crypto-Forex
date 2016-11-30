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
    public class ObjPastTrades
    {
      
        public decimal price { get; set; }
        public string amount { get; set; }
        /// <summary>
        /// return only trades after or at the time specified here
        /// </summary>
        public double timestamp { get; set; }
        /// <summary>
        /// return only trades before or a the time specified here
        /// </summary>
        public double until { get; set; }
        public string exchange { get; set; }
        /// <summary>
        /// Sell or Buy
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Currency you paid this trade's fee in
        /// </summary>
        public string fee_currency { get; set; }
        /// <summary>
        /// Amount of fees you paid for this trade
        /// </summary>
        public string fee_amount { get; set; }
        /// <summary>
        /// unique identification number of the trade
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// unique identification number of the parent order of the trade
        /// </summary>
        public int order_id { get; set; }


        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }

        [JsonIgnore]
        public TickTime TickTimeUntil
        {
            get { return TickTime.FromUnixTimeStamp(until); }
        }
    }
}
