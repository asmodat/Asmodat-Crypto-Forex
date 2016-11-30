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
        // TODO: NOT TESTED, unknown response

        /// <summary>
        /// View your funds currently borrowed and used in a margin position (active taken swaps).
        /// </summary>
        /// <returns>An array of your active taken swaps.</returns>
        public string GetActiveSwaps()
        {
            
            ObjRequestActiveSwaps variable = new ObjRequestActiveSwaps(Nonce);
            string response = this.Request(variable, "POST");

            throw new Exception("GetActiveSwaps: unknown response !");

            return response;
            //ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);
            //return result;
        }

       

    }
}
