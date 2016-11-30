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
        /// See your trading wallet information for margin trading.
        /// </summary>
        /// <returns></returns>
        public ObjMarginInfos GetMarginInfos()
        {
            
            ObjRequestMarginInfos variable = new ObjRequestMarginInfos(Nonce);
            string response = this.Request(variable, "POST");

            ObjMarginInfos result = JsonConvert.DeserializeObject<ObjMarginInfos[]>(response)[0];
            return result;
        }

       

    }
}
