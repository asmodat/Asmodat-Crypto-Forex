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
    public class ObjRequestTrades : ObjRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nonce"></param>
        /// <param name="symbol"></param>
        /// <param name="timestamp">Only show trades at or after this timestamp.</param>
        /// <param name="limit_trades">Limit the number of trades returned. Must be >= 1.</param>
        public ObjRequestTrades(
            string nonce, 
            ApiProperties.Symbols symbol, 
            double timestamp, 
            int? limit_trades = 50)
        {
            this.nonce = nonce;
            this.timestamp = timestamp;
            this.request = ApiProperties.TradesRequestUrl + @"/" + symbol.GetEnumName();


            if (limit_trades != null && limit_trades.Value >= 1)
                this.limit_trades = limit_trades.Value;
        }

        /// <summary>
        /// Only show trades at or after this timestamp.
        /// </summary>
        [JsonProperty("timestamp")]
        public double timestamp { get; set; }

        /// <summary>
        /// Limit the number of trades returned. Must be >= 1.
        /// </summary>
        [JsonProperty("limit_trades")]
        public int limit_trades { get; set; } = 50;
    }
}
