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
        

        public ObjMovements[] GetMovements(ApiProperties.Currency currency, ApiProperties.Methods method, TickTime since, TickTime until, int limit)
        {
            

            return GetMovements(
                currency.GetEnumName(),
                method.GetEnumName(),
                since.ToUnixTimeStamp(),
                until.ToUnixTimeStamp(),
                limit
                );
        }


        /// <summary>
        /// View your past deposits/withdrawals.
        /// </summary>
        /// <param name="currency">The currency to look for.</param>
        /// <param name="method">Optional. The method of the deposit/withdrawal (can be "bitcoin", "litecoin", "darkcoin", "wire").</param>
        /// <param name="since">Optional. Return only the history after this timestamp.</param>
        /// <param name="until">Optional. Return only the history before this timestamp.</param>
        /// <param name="limit">Optional. Limit the number of entries to return. Default is 500.</param>
        /// <returns>An array of histories:</returns>
        public ObjMovements[] GetMovements(string currency, string method, double since, double until, int limit)
        {

            ObjRequestMovements variable = new ObjRequestMovements(Nonce,  currency, method, since, until, limit);
            string response = this.Request(variable, "POST");

            ObjMovements[] result = JsonConvert.DeserializeObject<ObjMovements[]>(response);
            return result;
        }

       

    }
}
