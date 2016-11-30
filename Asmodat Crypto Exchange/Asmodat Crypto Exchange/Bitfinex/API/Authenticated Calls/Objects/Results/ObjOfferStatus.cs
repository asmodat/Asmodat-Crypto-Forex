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
    public class ObjOfferStatus
    {
        /// <summary>
        /// The currency name of the offer.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// The rate the offer was issued at (in % per 365 days).
        /// </summary>
        public decimal rate { get; set; }
        /// <summary>
        /// The number of days of the offer.
        /// </summary>
        public int period { get; set; }
        /// <summary>
        /// Either "lend" or "loan".
        /// </summary>
        public string direction { get; set; }
        /// <summary>
        /// Either "market" / "limit" / "stop" / "trailing-stop".
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// The timestamp the offer was submitted.
        /// </summary>
        public double timestamp { get; set; }
        /// <summary>
        /// Could the offer still be filled?
        /// </summary>
        public bool is_live { get; set; }
        /// <summary>
        /// Has the offer been cancelled?
        /// </summary>
        public bool is_cancelled { get; set; }
        /// <summary>
        /// How much of the offer has been executed so far in its history?
        /// </summary>
        public decimal executed_amount { get; set; }
        /// <summary>
        /// How much is still remaining to be submitted?
        /// </summary>
        public decimal remaining_amount { get; set; }
        /// <summary>
        /// What was the offer originally submitted for?
        /// </summary>
        public decimal original_amount { get; set; }


        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }


    }
}
