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
        /// Close a swap taken in a margin position
        /// </summary>
        /// <param name="swap_id">The swap ID given by `/taken_swaps`.</param>
        /// <returns></returns>
        public string GetCloseSwap(int swap_id)
        {

            ObjRequestCloseSwap variable = new ObjRequestCloseSwap(Nonce, swap_id);
            string response = this.Request(variable, "POST");

            throw new Exception("GetCloseSwap: unknown response !");
            return response;
            //ObjCancelOrder result = JsonConvert.DeserializeObject<ObjCancelOrder>(response);
            //return result;
        }

       

    }
}
