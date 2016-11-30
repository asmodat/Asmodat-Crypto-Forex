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
    public class ObjBalanceHistory
    {
        /// <summary>
        /// Currency
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Positive (credit) or negative (debit)
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// Wallet balance after the current entry
        /// </summary>
        public decimal balance { get; set; }
        /// <summary>
        /// Description of the entry. Includes the wallet in which the operation took place
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Timestamp of the entry
        /// </summary>
        public double timestamp { get; set; }


        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }

    }
}
