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
        /// Gives innermost bid and asks and information on the most recent trade, as well as high, low and volume of the last 24 hours.
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public ObjTicker GetTicker(ApiProperties.Symbols symbol)
        {
            ObjTicker result = null;
            try
            {
                ObjRequestTicker variable = new ObjRequestTicker(Nonce, symbol);
                string response = this.Request(variable, "GET");

                result = JsonConvert.DeserializeObject<ObjTicker>(response);
            }
            catch(Exception ex)
            {
                ex.ToOutput();
            }

            return result;
        }

       

    }
}
