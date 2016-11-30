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
        /// Get the full lend book:
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="limit_bids"></param>
        /// <param name="limit_asks"></param>
        /// <returns></returns>
        public ObjLendbook GetLendbook(
            ApiProperties.Currency currency, 
            int? limit_bids = null, 
            int? limit_asks = null)
        {

            ObjRequestLendbook variable = new ObjRequestLendbook(Nonce, currency, limit_bids, limit_asks);
            string response = this.Request(variable, "GET");

            ObjLendbook result = JsonConvert.DeserializeObject<ObjLendbook>(response);

            return result;
        }

       

    }
}
