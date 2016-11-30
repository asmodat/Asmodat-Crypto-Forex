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
        /// Cancel all active orders at once.
        /// </summary>
        /// <returns>Confirmation of cancellation of all active orders.</returns>
        public ObjCancelOrder GetCancelAllActiveOrders()
        {

            ObjRequestCancelAllActiveOrders variable = new ObjRequestCancelAllActiveOrders(Nonce);
            string response = this.Request(variable, "POST");

            ObjCancelOrder result = JsonConvert.DeserializeObject<ObjCancelOrder>(response);
            return result;
        }

       

    }
}
