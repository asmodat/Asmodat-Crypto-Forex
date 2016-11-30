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
    public class ObjRequestOrderbook : ObjRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nonce"></param>
        /// <param name="symbol"></param>
        /// <param name="limit_bids"></param>
        /// <param name="limit_asks"></param>
        /// <param name="group">Can be only 1 or 0</param>
        public ObjRequestOrderbook(
            string nonce, 
            ApiProperties.Symbols symbol, 
            int? limit_bids = 50, 
            int? limit_asks = 50, 
            int? group = 1)
        {
            this.nonce = nonce;
            this.request = ApiProperties.OrderbookRequestUrl + @"/" + symbol.GetEnumName();

            if (limit_bids != null && limit_bids.Value >= 0)
                this.limit_bids = limit_bids.Value;

            if (limit_asks != null && limit_asks.Value >= 0)
                this.limit_asks = limit_asks.Value;

            if (group != null && (group.Value == 0 || group.Value == 1))
                this.group = group.Value;
        }

        /// <summary>
        /// Limit the number of bids (loan demands) returned. 
        /// May be 0 in which case the array of bids is empty.
        /// Default: 50
        /// </summary>
        public int limit_bids { get; set; } = 50;

        /// <summary>
        /// Limit the number of asks (loan offers) returned. 
        /// May be 0 in which case the array of asks is empty.
        /// Default: 50
        /// </summary>
        public int limit_asks { get; set; } = 50;

        /// <summary>
        /// If 1, orders are grouped by price in the orderbook. 
        /// If 0, orders are not grouped and sorted individually
        /// </summary>
        public int group { get; set; } = 1;
    }
}
