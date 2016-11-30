using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Abbreviate;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequestBalanceHistory : ObjRequest
    {
        public ObjRequestBalanceHistory(string nonce, string currency, double since, double until, int limit, string wallet)
        {
            this.nonce = nonce;
            this.currency = currency;
            this.since = since.ToString();
            this.until = until.ToString();
            this.limit = limit;
            this.wallet = wallet;

            this.request = ApiProperties.BalanceHistoryRequestUrl; 
        }

        /// <summary>
        /// The currency to look for.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Optional. Return only the history after this timestamp.
        /// </summary>
        public string since { get; set; }
        /// <summary>
        /// Optional. Return only the history before this timestamp.
        /// </summary>
        public string until { get; set; }
        /// <summary>
        /// Optional. Limit the number of entries to return. Default is 500
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// Optional. Return only entries that took place in this wallet. Accepted inputs are: "trading", "exchange", "deposit".
        /// </summary>
        public string wallet { get; set; }

    }
}
