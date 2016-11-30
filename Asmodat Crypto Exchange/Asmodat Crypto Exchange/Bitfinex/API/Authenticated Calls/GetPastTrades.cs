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
        /// View your past trades.
        /// </summary>
        /// <param name="symbol">The pair traded (BTCUSD, LTCUSD, LTCBTC).</param>
        /// <param name="timestamp">Trades made before this timestamp won't be returned.</param>
        /// <param name="until">Optional. Trades made after this timestamp won't be returned.</param>
        /// <param name="limit_trades">Optional. Limit the number of trades returned. Default is 50.</param>
        /// <param name="reverse">Optional. Return trades in reverse order (the oldest comes first). Default is returning newest trades first.</param>
        /// <returns>An array of trades:</returns>
        public ObjPastTrades[] GetPastTrades(ApiProperties.Symbols symbol, TickTime timestamp, TickTime until, int limit_trades, int reverse)
        {
            

            return GetPastTrades(
                symbol.GetEnumName(),
                timestamp.ToUnixTimeStamp(),
                until.ToUnixTimeStamp(),
                limit_trades,
                reverse
                );
        }


        /// <summary>
        /// View your past trades.
        /// </summary>
        /// <param name="symbol">The pair traded (BTCUSD, LTCUSD, LTCBTC).</param>
        /// <param name="timestamp">Trades made before this timestamp won't be returned.</param>
        /// <param name="until">Optional. Trades made after this timestamp won't be returned.</param>
        /// <param name="limit_trades">Optional. Limit the number of trades returned. Default is 50.</param>
        /// <param name="reverse">Optional. Return trades in reverse order (the oldest comes first). Default is returning newest trades first.</param>
        /// <returns>An array of trades:</returns>
        public ObjPastTrades[] GetPastTrades(string symbol, double timestamp, double until, int limit_trades, int reverse)
        {

            ObjRequestPastTrades variable = new ObjRequestPastTrades(Nonce, symbol, timestamp, until, limit_trades, reverse);
            string response = this.Request(variable, "POST");

            ObjPastTrades[] result = JsonConvert.DeserializeObject<ObjPastTrades[]>(response);
            return result;
        }

       

    }
}
