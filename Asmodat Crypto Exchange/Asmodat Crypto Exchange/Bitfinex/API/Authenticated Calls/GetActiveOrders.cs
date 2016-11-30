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
        /// View your active orders.
        /// </summary>
        /// <returns>An array of the results of `/order/status` for all your live orders.</returns>
        public ObjOrderStatus[] GetActiveOrders()
        {

            ObjRequestActiveOrders variable = new ObjRequestActiveOrders(Nonce);
            string response = this.Request(variable, "POST");


            ObjOrderStatus[] result = JsonConvert.DeserializeObject<ObjOrderStatus[]>(response);
            return result;
        }

       

    }
}
