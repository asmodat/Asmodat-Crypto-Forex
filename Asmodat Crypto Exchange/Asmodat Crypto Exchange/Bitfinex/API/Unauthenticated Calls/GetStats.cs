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
        /// Various statistics about the requested pairs.
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public List<ObjStats> GetStats(ApiProperties.Symbols symbol)
        {
            ObjRequestStats variable = new ObjRequestStats(Nonce, symbol);
            string response = this.Request(variable, "GET");

            List<ObjStats> result = JsonConvert.DeserializeObject<List<ObjStats>>(response);
            
            return result;
        }

       

    }
}
