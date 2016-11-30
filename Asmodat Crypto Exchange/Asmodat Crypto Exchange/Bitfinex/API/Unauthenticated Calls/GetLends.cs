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
        /// Get a list of the most recent swaps data for the given currency: 
        /// total amount lent and Flash Return Rate (in % by 365 days) over time.
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="timestamp">Only show data at or after this timestamp.</param>
        /// <param name="limit_lends">Limit the number of swaps data returned. Must be >= 1</param>
        /// <returns></returns>
        public List<ObjLends> GetLends(
            ApiProperties.Currency currency, 
            double timestamp, 
            int? limit_lends = null)
        {
            
            ObjRequestLends variable = new ObjRequestLends(Nonce, currency, timestamp, limit_lends);
            string response = this.Request(variable, "GET");

            List<ObjLends> result = JsonConvert.DeserializeObject<List<ObjLends>>(response);

            return result;
        }

       

    }
}
