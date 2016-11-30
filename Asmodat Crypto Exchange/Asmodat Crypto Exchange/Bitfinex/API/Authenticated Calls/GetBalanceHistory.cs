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
        /// View all of your balance ledger entries.
        /// </summary>
        /// <param name="currency">The currency to look for.</param>
        /// <param name="since">Optional. Return only the history after this timestamp.</param>
        /// <param name="until">Optional. Return only the history before this timestamp.</param>
        /// <param name="limit">Optional. Limit the number of entries to return. Default is 500.</param>
        /// <param name="wallet">Optional. Return only entries that took place in this wallet. Accepted inputs are: "trading", "exchange", "deposit".</param>
        /// <returns></returns>
        public ObjBalanceHistory GetBalanceHistory(ApiProperties.Currency currency, TickTime since, TickTime until, int limit, ApiProperties.WalletName wallet)
        {
            

            return GetBalanceHistory(
                currency.GetEnumName(),
                since.ToUnixTimeStamp(),
                until.ToUnixTimeStamp(),
                limit,
                wallet.GetEnumName()
                );
        }

        //TODO: NOT TESTED
        /// <summary>
        /// View all of your balance ledger entries.
        /// </summary>
        /// <param name="currency">The currency to look for.</param>
        /// <param name="since">Optional. Return only the history after this timestamp.</param>
        /// <param name="until">Optional. Return only the history before this timestamp.</param>
        /// <param name="limit">Optional. Limit the number of entries to return. Default is 500.</param>
        /// <param name="wallet">Optional. Return only entries that took place in this wallet. Accepted inputs are: "trading", "exchange", "deposit".</param>
        /// <returns></returns>
        public ObjBalanceHistory GetBalanceHistory(string currency, double since, double until, int limit, string wallet)
        {

            ObjRequestBalanceHistory variable = new ObjRequestBalanceHistory(Nonce,  currency,  since,  until,  limit,  wallet);
            string response = this.Request(variable, "POST");

            ObjBalanceHistory result = JsonConvert.DeserializeObject<ObjBalanceHistory>(response);
            return result;
        }

       

    }
}
