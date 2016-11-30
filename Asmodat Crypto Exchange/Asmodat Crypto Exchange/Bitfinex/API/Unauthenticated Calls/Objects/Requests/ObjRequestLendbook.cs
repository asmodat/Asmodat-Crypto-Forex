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
    public class ObjRequestLendbook : ObjRequest
    {
        public ObjRequestLendbook(
            string nonce, 
            ApiProperties.Currency currency, 
            int? limit_bids = 50, 
            int? limit_asks = 50)
        {
            this.nonce = nonce;
            this.request = ApiProperties.LendbookRequestUrl + @"/" + currency.GetEnumName();

            if (limit_bids != null && limit_bids.Value >= 0)
                this.limit_bids = limit_bids.Value;

            if (limit_asks != null && limit_asks.Value >= 0)
                this.limit_asks = limit_asks.Value;
        }


        public ObjRequestLendbook(
            string nonce,
            string currency,
            int limit_bids = 50,
            int limit_asks = 50)
        {
            this.nonce = nonce;
            this.limit_bids = limit_bids;
            this.limit_asks = limit_asks;

            this.request = ApiProperties.LendbookRequestUrl + @"/" + currency.GetEnumName();
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
    }
}
