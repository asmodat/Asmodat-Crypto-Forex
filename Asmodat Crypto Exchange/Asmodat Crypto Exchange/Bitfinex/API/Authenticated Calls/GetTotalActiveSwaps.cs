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
        // TODO: NOT TESTED

        /// <summary>
        /// View the total of your active swaps used in your position(s).
        /// </summary>
        /// <returns>An array of the following: position_pair & total_swaps</returns>
        public ObjTotalActiveSwaps[] GetTotalActiveSwaps()
        {

            ObjRequestTotalActiveSwaps variable = new ObjRequestTotalActiveSwaps(Nonce);
            string response = this.Request(variable, "POST");


            ObjTotalActiveSwaps[] result = JsonConvert.DeserializeObject<ObjTotalActiveSwaps[]>(response);
            return result;
        }

       

    }
}
