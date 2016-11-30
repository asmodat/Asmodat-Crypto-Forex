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
    public class ObjRequestPastTrades : ObjRequest
    {
        public ObjRequestPastTrades(string nonce, string symbol, double timestamp, double until, int limit_trades,  int reverse)
        {
            this.nonce = nonce;
            this.symbol = symbol;
            this.timestamp = timestamp.ToString();
            this.until = until.ToString();
            this.limit_trades = limit_trades;
            this.reverse = reverse;
            
            this.request = ApiProperties.PastTradesRequestUrl; 
        }

        /// <summary>
        /// The pair traded (BTCUSD, LTCUSD, LTCBTC).
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// Trades made before this timestamp won't be returned.
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// Optional. Trades made after this timestamp won't be returned.
        /// </summary>
        public string until { get; set; }
        /// <summary>
        /// Optional. Limit the number of trades returned. Default is 50.
        /// </summary>
        public int limit_trades { get; set; }
        /// <summary>
        /// Optional. Return trades in reverse order (the oldest comes first). 
        /// Default is returning newest trades first.
        /// </summary>
        public int reverse { get; set; }

    }
}
