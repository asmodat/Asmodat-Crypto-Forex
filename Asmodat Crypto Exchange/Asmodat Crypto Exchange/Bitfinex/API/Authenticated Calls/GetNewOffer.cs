using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Asmodat.BitfinexV1.API;
using Newtonsoft.Json;

using Asmodat.Abbreviate;
using Asmodat.Debugging;
using System.IO;
using Asmodat.Types;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {
        //TODO: NOT TESTED

        /// <summary>
        /// Submit a new offer.
        /// </summary>
        /// <param name="currency">The name of the currency.</param>
        /// <param name="amount">Offer size: how much to lend or borrow.</param>
        /// <param name="rate">Rate to lend or borrow at. In percentage per 365 days.</param>
        /// <param name="period">Number of days of the loan (in days)</param>
        /// <param name="direction">Either "lend" or "loan".</param>
        /// <returns></returns>
        public ObjNewOffer GetNewOffer(ApiProperties.Currency currency, decimal amount, decimal rate, int period, ApiProperties.Directions direction)
        {
            

            return GetNewOffer(
                currency.GetEnumName(),
                amount,
                rate,
                period,
                direction.GetEnumName()
                );
        }


        /// <summary>
        /// Submit a new offer.
        /// </summary>
        /// <param name="currency">The name of the currency.</param>
        /// <param name="amount">Offer size: how much to lend or borrow.</param>
        /// <param name="rate">Rate to lend or borrow at. In percentage per 365 days.</param>
        /// <param name="period">Number of days of the loan (in days)</param>
        /// <param name="direction">Either "lend" or "loan".</param>
        /// <returns></returns>
        public ObjNewOffer GetNewOffer(string currency, decimal amount, decimal rate, int period, string direction)
        {

            ObjRequestNewOffer variable = new ObjRequestNewOffer(Nonce, currency, amount, rate, period, direction);
            string response = this.Request(variable, "POST");

            ObjNewOffer result = JsonConvert.DeserializeObject<ObjNewOffer>(response);
            return result;
        }

       

    }
}
