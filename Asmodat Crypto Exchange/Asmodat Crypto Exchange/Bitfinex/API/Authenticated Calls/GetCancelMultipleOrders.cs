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
        /// Cancel multiples orders at once.
        /// </summary>
        /// <param name="order_ids">An array of the order IDs given by `/order/new` or `/order/new/multi`</param>
        /// <returns></returns>
        public ObjCancelOrder GetCancelMultipleOrders(int[] order_ids)
        {

            ObjRequestCancelMultipleOrders variable = new ObjRequestCancelMultipleOrders(Nonce, order_ids);
            string response = this.Request(variable, "POST");

            ObjCancelOrder result = JsonConvert.DeserializeObject<ObjCancelOrder>(response);
            return result;
        }

       

    }
}
