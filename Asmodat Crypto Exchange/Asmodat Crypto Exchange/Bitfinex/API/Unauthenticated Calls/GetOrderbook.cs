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
        /// Get the full order book.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="limit_bids"></param>
        /// <param name="limit_asks"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public ObjOrderbook GetOrderbook(
            ApiProperties.Symbols symbol, 
            int? limit_bids = null, 
            int? limit_asks = null, 
            int? group = null)
        {

            ObjRequestOrderbook variable = new ObjRequestOrderbook(Nonce, symbol, limit_bids, limit_asks, group);
            string response = this.Request(variable, "GET");

            ObjOrderbook result = JsonConvert.DeserializeObject<ObjOrderbook>(response);

            return result;
        }

       

    }
}
