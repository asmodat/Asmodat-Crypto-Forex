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
        /// TODO: NOT TESTED
        /// Cancel an order.
        /// </summary>
        /// <param name="order_id">The order ID given by `/order/new`.</param>
        /// <returns></returns>
        public ObjCancelOrder GetCancelOrder(int order_id)
        {

            ObjRequestCancelOrder variable = new ObjRequestCancelOrder(Nonce, order_id);
            string response = this.Request(variable, "POST");

            ObjCancelOrder result = JsonConvert.DeserializeObject<ObjCancelOrder>(response);
            return result;
        }

       

    }
}
