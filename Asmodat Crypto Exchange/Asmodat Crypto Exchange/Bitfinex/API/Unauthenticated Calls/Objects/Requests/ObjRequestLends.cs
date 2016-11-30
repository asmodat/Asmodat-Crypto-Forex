using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Abbreviate;
using Newtonsoft.Json;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequestLends : ObjRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nonce"></param>
        /// <param name="currency"></param>
        /// <param name="timestamp">Only show trades at or after this timestamp.</param>
        /// <param name="limit_lends">Limit the number of swaps data returned. Must be >= 1</param>
        public ObjRequestLends(
            string nonce, 
            ApiProperties.Currency currency, 
            double timestamp, 
            int? limit_lends = 50)
        {
            this.nonce = nonce;
            this.timestamp = timestamp;
            this.request = ApiProperties.LendsRequestUrl + @"/" + currency.GetEnumName();


            if (limit_lends != null && limit_lends.Value >= 1)
                this.limit_lends = limit_lends.Value;
        }

        /// <summary>
        /// Only show trades at or after this timestamp.
        /// </summary>
        [JsonProperty("timestamp")]
        public double timestamp { get; set; }

        /// <summary>
        /// Limit the number of swaps data returned. Must be >= 1
        /// </summary>
        [JsonProperty("limit_lends")]
        public int limit_lends { get; set; } = 50;
    }
}
