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
    public class ObjRequestMovements : ObjRequest
    {
        public ObjRequestMovements(string nonce, string currency, string method, double since, double until, int limit = 500)
        {
            this.nonce = nonce;
            this.currency = currency;
            this.method = method;
            this.since = since.ToString();
            this.until = until.ToString();
            this.limit = limit;
            

            this.request = ApiProperties.MovementsHistoryRequestUrl; 
        }

        /// <summary>
        /// The currency to look for.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Optional. The method of the deposit/withdrawal (can be "bitcoin", "litecoin", "darkcoin", "wire").
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// Optional. Return only the history after this timestamp.
        /// </summary>
        public string since { get; set; }
        /// <summary>
        /// Optional. Return only the history before this timestamp.
        /// </summary>
        public string until { get; set; }
        /// <summary>
        /// Optional. Limit the number of entries to return. Default is 500.
        /// </summary>
        public int limit { get; set; } = 500;
        

    }
}
