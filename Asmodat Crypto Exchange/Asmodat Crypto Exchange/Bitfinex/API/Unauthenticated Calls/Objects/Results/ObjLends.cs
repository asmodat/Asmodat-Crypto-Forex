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
    public class ObjLends
    {
        /// <summary>
        /// Average rate of total swaps opened at fixed rates, ie past Flash Return Rate annualized
        /// decimal, % by 365 days
        /// </summary>
        public decimal rate { get; set; }
        /// <summary>
        /// Total amount of open swaps in the given currency
        /// </summary>
        public decimal amount_lent { get; set; }
        /// <summary>
        /// Total amount of open swaps used in a margin position in the given currency
        /// </summary>
        public decimal amount_used { get; set; }
        public double timestamp { get; set; }
        

        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
