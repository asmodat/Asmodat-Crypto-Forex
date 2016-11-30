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
    public class ObjRequestNewOffer : ObjRequest
    {


        public ObjRequestNewOffer(string nonce, string currency, decimal amount, decimal rate, int period, string direction)
        {
            this.nonce = nonce;
            this.currency = currency;
            this.amount = amount.ToString();
            this.rate = rate.ToString();
            this.period = period;
            this.direction = direction;
            
            this.request = ApiProperties.NewOfferRequestUrl; 
        }

        /// <summary>
        /// The name of the currency.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Offer size: how much to lend or borrow.
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Rate to lend or borrow at. In percentage per 365 days.
        /// </summary>
        public string rate { get; set; }
        /// <summary>
        /// Number of days of the loan (in days)
        /// </summary>
        public int period { get; set; }
        /// <summary>
        /// Either "lend" or "loan".
        /// </summary>
        public string direction { get; set; }

    }
}
