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

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {
        /// <summary>
        /// Get a list of the most recent trades for the given symbol.
        /// </summary>
        /// <param name="pair">symbol</param>
        /// <param name="timestamp">Only show trades at or after this timestamp.</param>
        /// <param name="limit_trades">Limit the number of trades returned. Must be >= 1.</param>
        /// <returns></returns>
        public List<ObjTrades> GetTrades(ApiProperties.Symbols symbol, double timestamp, int? limit_trades = null)
        {

            ObjRequestTrades variable = new ObjRequestTrades(Nonce, symbol, timestamp, limit_trades);
            string response = this.Request(variable, "GET");

            List<ObjTrades> result = JsonConvert.DeserializeObject<List<ObjTrades>>(response);

            return result;
        }

       

    }
}
