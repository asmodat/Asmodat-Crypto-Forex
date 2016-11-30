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
    public class ObjOrderStatus
    {
        /// <summary>
        /// The symbol name the order belongs to.
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// "bitfinex", "bitstamp".
        /// </summary>
        public string exchange { get; set; }
        /// <summary>
        /// The price the order was issued at (can be null for market orders).
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// The average price at which this order as been executed so far. 0 if the order has not been executed at all.
        /// </summary>
        public decimal avg_execution_price { get; set; }
        /// <summary>
        /// Either "buy" or "sell".
        /// </summary>
        public string side { get; set; }
        /// <summary>
        /// Either "market" / "limit" / "stop" / "trailing-stop".
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// The timestamp the order was submitted.
        /// </summary>
        public double timestamp { get; set; }
        /// <summary>
        /// Could the order still be filled?
        /// </summary>
        public bool is_live { get; set; }
        /// <summary>
        /// Has the order been cancelled?
        /// </summary>
        public bool is_cancelled { get; set; }
        /// <summary>
        /// Is the order hidden?
        /// </summary>
        public bool is_hidden { get; set; }
        /// <summary>
        /// For margin only true if it was forced by the system.
        /// </summary>
        public bool was_forced { get; set; }
        /// <summary>
        /// How much of the order has been executed so far in its history?
        /// </summary>
        public decimal executed_amount { get; set; }
        /// <summary>
        /// How much is still remaining to be submitted?
        /// </summary>
        public decimal remaining_amount { get; set; }
        /// <summary>
        /// What was the order originally submitted for?
        /// </summary>
        public decimal original_amount { get; set; }


        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
