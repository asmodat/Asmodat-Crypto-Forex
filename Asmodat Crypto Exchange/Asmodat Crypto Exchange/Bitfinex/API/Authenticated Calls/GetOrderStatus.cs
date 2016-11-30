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

        //TODO: NOT TESTED
      
        public ObjOrderStatus GetOrderStatus(int order_id)
        {

            ObjRequestOrderStatus variable = new ObjRequestOrderStatus(Nonce, order_id);
            string response = this.Request(variable, "POST");

            ObjOrderStatus result = JsonConvert.DeserializeObject<ObjOrderStatus>(response);
            return result;
        }

       

    }
}
